using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private AudioSource AudioSource;
	public AudioClip uiSound;

	// Use this for initialization
	void Start () {
		Debug.Log (PlayerPrefs.GetFloat ("BestTime"));
		AudioSource = GetComponent<AudioSource> ();
		AudioSource.clip = uiSound;
		Button btnS = GameObject.Find ("Start").GetComponent<Button> ();
		btnS.onClick.AddListener (StartOnClick);
		Button btnSe = GameObject.Find ("Settings").GetComponent<Button> ();
		btnSe.onClick.AddListener (SettingsOnClick);
		Button btnC = GameObject.Find ("Credits").GetComponent<Button> ();
		btnC.onClick.AddListener (CreditsOnClick);
		Button btnE = GameObject.Find ("Exit").GetComponent<Button> ();
		btnE.onClick.AddListener (ExitOnClick);
	}
	
	void StartOnClick(){
		AudioSource.Play ();
		StartCoroutine ("startLoad");

	}
	IEnumerator startLoad(){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("LevelSelect");
	}

	void SettingsOnClick(){
		AudioSource.Play ();
		StartCoroutine ("settingsLoad");
	}
	IEnumerator settingsLoad(){
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("Settings");
	}

	void CreditsOnClick(){
		AudioSource.Play ();
		StartCoroutine ("CreditsLoad");
	}
	IEnumerator CreditsLoad(){
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("Credits");
	}

	void ExitOnClick(){
		AudioSource.Play ();
		StartCoroutine ("ExitLoad");
	}
	IEnumerator ExitLoad(){
		yield return  new WaitForSeconds (0.5f);
		Application.Quit();
	}
}
