using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Wind Audio Object
 * 
 * Similar to Prop Audio Object for procedural wind generation. Sends a 
 * randomized seed as a Wwise RTPC that is then passed into PureData through
 * a Heavy parameter. 
 */

public class WindAudioObject : MonoBehaviour {

	[SerializeField] public AK.Wwise.Event m_seededEvent;
	[SerializeField] public AK.Wwise.RTPC m_seedParameter;

    private float gizmoRadius = 50.0f;
	private float smallGizmoRadius = 5f;



	void Start () {
		uint result;
		m_seedParameter.SetValue (gameObject, Random.Range (0, 100));
		result = m_seededEvent.Post (gameObject);
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.green;
		Gizmos.DrawSphere (transform.position, smallGizmoRadius);
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.gray;
		Gizmos.DrawWireSphere (transform.position, gizmoRadius);
	}
}
