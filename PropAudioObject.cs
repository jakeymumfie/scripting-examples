using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Prop Audio Object
 * 
 * For spatialized ambient loops associated with specific props. Uses
 * an enable toggle to control individual props from a prefab, i.e. for 
 * destroyed pumps.
 */

public class PropAudioObject : MonoBehaviour {

    [SerializeField] public bool m_enableAudio = false;
	[SerializeField] public AK.Wwise.Event m_audioEvent = null;
	private float gizmoRadius = 50.0f;

	void Start() {
        if (m_enableAudio)
            m_audioEvent.Post(gameObject);
        else
            enabled = false;
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
	}

	private void OnDrawGizmos()
	{
        float gizmoRadius2 = gizmoRadius / 5;
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, gizmoRadius2);
	}
}
