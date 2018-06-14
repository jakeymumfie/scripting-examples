using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player Animation Sounds
 * 
 * Logic for footstep and jump audio with speed and material switches. All
 * methods in this script are called from animation timeline. Material switches 
 * were not implemented due to time constraints. 
 */

public class PlayerAnimationSounds : MonoBehaviour
{
	[Header("EventNames")]
	[SerializeField] AK.Wwise.Event m_footstep;
	[SerializeField] AK.Wwise.Event m_footstepServo;
	[SerializeField] AK.Wwise.Event m_jump;
	[SerializeField] AK.Wwise.Event m_land;

	[Header("SwitchNames")]
	[SerializeField] AK.Wwise.Switch m_run;
	[SerializeField] AK.Wwise.Switch m_walk;
	[SerializeField] AK.Wwise.Switch m_snow;
	[SerializeField] AK.Wwise.Switch m_ice;
	[SerializeField] AK.Wwise.Switch m_metal;


    [SerializeField] ParticleSystem footstepParticle;

    public void Start()
    {
		m_run.SetValue (gameObject);
		m_snow.SetValue (gameObject);
    }

    public void PlayFootfallSound()
    {
        if (!ThirdPersonController.characterController.isGrounded) 
            return;

        Vector3 vel = ThirdPersonController.characterController.velocity;
        vel = transform.InverseTransformVector(vel);
        if (footstepParticle) 
            footstepParticle.Play();

        if (vel.z > 0)
			m_run.SetValue(gameObject);
        else
			m_walk.SetValue(gameObject);

		m_footstep.Post(gameObject);

    }

	public void PlayFootfallServo()
	{
		Vector3 vel = ThirdPersonController.characterController.velocity;
		vel = transform.InverseTransformVector(vel);
		if (footstepParticle) 
            footstepParticle.Play();

		if (vel.z > 0)
			m_run.SetValue(gameObject);
		else
			m_walk.SetValue(gameObject);

		m_footstepServo.Post(gameObject);

	}

	public void PlayJumpSound()
	{
		if (!ThirdPersonController.characterController.isGrounded) 
            return;

		m_jump.Post (gameObject);
	}

	public void PlayLandingSound()
	{
		if (!ThirdPersonController.characterController.isGrounded) 
            return;

		m_land.Post (gameObject);
	}
}
