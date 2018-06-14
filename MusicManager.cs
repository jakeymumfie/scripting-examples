using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Music Manager
 * 
 * Has switching capabilities for menu, gameplay, and combat, but 
 * combat was never implemented due to time constraints. Instead,
 * combat tracks were added in gameplay random playlist in Wwise.
 * This script mostly handles menu to gameplay to menu switching 
 * and initializing to the right state.
 */

public class MusicManager : MonoBehaviour {

	[SerializeField] bool m_isMenu;
	[Space]
	[Header("Wwise Hooks")]
	[SerializeField] AK.Wwise.Event m_musicEvent = null;
	//[SerializeField]  m_musicStateGroup = null;
	[SerializeField] AK.Wwise.Event m_menuStateEvent = null;
	[SerializeField] AK.Wwise.Event m_gameplayStateEvent = null;
	[SerializeField] AK.Wwise.Event m_combatStateEvent = null;

    private static MusicManager m_instance;

	public enum MusicState {
		Menu,
		Gameplay,
		Combat
	};

	public bool IsMenu {
		set {
			m_isMenu = value;

			if (IsMenu) 
				SetState (MusicState.Menu);
			else 
				SetState (MusicState.Gameplay);
			
		}
		get {
			return m_isMenu;
		}
	}

	void Awake() {
		if (!m_instance) 
			m_instance = this;

		else
			m_instance.IsMenu = this.IsMenu;

			Destroy (this.gameObject);
		}

		DontDestroyOnLoad (this.gameObject);
	}

	void Start () {
		//Debug.Log ("Music Manager Start(): isMenu = " + m_isMenu);

		if (IsMenu) 
			SetState (MusicState.Menu);
		else 
			SetState (MusicState.Gameplay);
		
		StartMusic (); 
	}

	void StartMusic() {
		m_musicEvent.Post (gameObject);
	}

	public void SetState(MusicState _state) {
		switch (_state) {
        case MusicState.Menu:
			//AkSoundEngine.SetState ("MusicState" , m_menuState.ToString());
			m_menuStateEvent.Post(gameObject);
			break;
		case MusicState.Gameplay:
			//AkSoundEngine.SetState ("MusicState" , m_gameplayState.ToString());
			m_gameplayStateEvent.Post(gameObject);
			break;
		case MusicState.Combat:
			//AkSoundEngine.SetState ("MusicState" , m_combatState.ToString());
			m_combatStateEvent.Post(gameObject);
			break;
		}
	}

    public void SetGameplay()
    {
        SetState(MusicState.Gameplay);
    }
}
