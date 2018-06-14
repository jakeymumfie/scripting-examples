using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Interactor Sounds
 * 
 * Simple container class for Interactor minigame sfx
 */

public class InteractorSounds : MonoBehaviour {

	[Header("References")]
	[SerializeField] GameObject m_gameObject;
	[SerializeField] AK.Wwise.Event m_meterCharge;
	[SerializeField] AK.Wwise.Event m_holdLeft;
	[SerializeField] AK.Wwise.Event m_holdRight;
	[SerializeField] AK.Wwise.Event m_failLeft;
	[SerializeField] AK.Wwise.Event m_failRight;
	[SerializeField] AK.Wwise.Event m_reset;
	[SerializeField] AK.Wwise.Event m_success;
	[Space]
	[SerializeField] AK.Wwise.RTPC m_trialNumber;


	void Start() {
		if (m_gameObject == null) {
			//Debug.Log ("Game Object Reference not set on: " + gameObject.name);
			m_gameObject = gameObject;
		}
	}


	public void reset() {
		m_reset.Post (m_gameObject);
	}

	public void setTrialNumber(float _trialNumber) {
		m_trialNumber.SetValue (m_gameObject, _trialNumber);
	}

	public void charge() {
		m_meterCharge.Post (m_gameObject);
	}

	public void holdLeft() {
		m_holdLeft.Post (m_gameObject);
	}

	public void holdRight() {
		m_holdRight.Post (m_gameObject);
	}

	public void failLeft() {
		m_failLeft.Post (m_gameObject);
	}

	public void failRight() {
		m_failRight.Post (m_gameObject);
	}

	public void success() {
		m_success.Post (m_gameObject);
	}

}
