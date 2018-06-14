using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Dynamic Sound Container
 * 
 * Class for holding dynamically generated audio events. Keeps track of how many 
 * events are posted to it and destroys its instance once all events are over.
 */

public class DynamicSoundContainer : MonoBehaviour {

	public bool m_flagForDeath = false;
	private int m_playingEvents;



	void Start () 
	{
		m_playingEvents = 0;
	}


    public void setFlagForDeath (bool _flag) 
    {
		m_flagForDeath = _flag;
	}


    public void PostEvent (AK.Wwise.Event _akEvent, bool _killOnEventEnd)
	{
        uint result;

        result = _akEvent.Post(gameObject, (uint)AkCallbackType.AK_EndOfEvent, EventEndCallback, null);
        if (_killOnEventEnd)
            m_flagForDeath = _killOnEventEnd;

        // Check if an event actually started, then update number of playing events
        if (result != 0)
            m_playingEvents++;
	}


    public void PostEventSimple (AK.Wwise.Event _akEvent)
	{
		_akEvent.Post (gameObject);
	}


    private void EventEndCallback(object _notUsed, AkCallbackType _callbackType, AkCallbackInfo _notUsedEither)
	{
		if(_notUsed != null)
        {
            // Check for proper callback type
            if (_callbackType == AkCallbackType.AK_EndOfEvent)
            {
                // If this is the last event to finish that's been called on this gameObject, destroy it
                m_playingEvents -= 1;
                if (m_playingEvents == 0)
                {
                    if (m_flagForDeath)
                    {
                        OnAllEventsFinished();
                    }
                }
            }
        }
    }


	private void OnAllEventsFinished()
	{
		Destroy (gameObject);
	}


    public void RTPCUpdate(AK.Wwise.RTPC _rtpc, float _value)
	{
		_rtpc.SetValue (gameObject, _value);
	}


    public void TransformUpdate(Transform _transform) 
	{
		AkSoundEngine.SetObjectPosition (gameObject, _transform);
	}
}
