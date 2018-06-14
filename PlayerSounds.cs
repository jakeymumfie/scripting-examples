using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Player Sounds
 * 
 * Logic for player take damage, death, and respawn sfx. Taking damage sound
 * only plays one at a time using event callbacks.
 */

namespace Combat
{
    public class PlayerSounds : UnitBehaviour, IDamageTarget
    {
        [Header("Wwise IDs")]
        [SerializeField] AK.Wwise.Event m_damageEvent;
		[SerializeField] AK.Wwise.RTPC m_healthRTPC;
		[SerializeField] AK.Wwise.CallbackFlags m_damageCallbackFlag = null;
		[SerializeField] AK.Wwise.Event m_deathEvent;
		[SerializeField] AK.Wwise.Event m_respawnEvent;


        private bool isPlaying = false;

        public static PlayerSounds instance;

        void Awake()
        {
            if (!instance)
                instance = this;
            else
                Destroy(this);
        }

        public void takeDamage()
        {
            uint result;

            // Posts event, but waits for endOfEvent callback before being able to post again
            if (!isPlaying)
            {
                result = m_damageEvent.Post(gameObject, m_damageCallbackFlag, EventCallback, null);

                if (result != 0)
                    isPlaying = true;
            }
        }

        public void setHealth(float _newHealth)
        {
            m_healthRTPC.SetGlobalValue(_newHealth);
        }

        private void EventCallback(object _cookie, AkCallbackType _type, AkCallbackInfo _info)
        {
            if (_type == AkCallbackType.AK_EndOfEvent)
            {
                var markerInfo = _info as AkMarkerCallbackInfo;
                if (markerInfo != null)
                    isPlaying = false;
            }
        }

        public void OnReceiveDamage(DamageEvent _eventData)
        {
            Damage damage = _eventData.damage;

            float delta = unit.health.delta * 100f;
            setHealth(delta);
        }

		public void PlayDeathSound()
		{
			m_deathEvent.Post (gameObject);
		}

		public void PlayRespawnSound()
		{
			// resets health parameter in wwise globally
			m_respawnEvent.Post (gameObject);
		}
    }

}