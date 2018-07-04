using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
	public Slider musicS;
	public Slider sfxS;
	private static bool created = false;

	private Scene currentScene;

	private AudioSource AudioSource;
	public AudioClip mainMenu;
	public AudioClip game;

	private bool MusicStarted = false;

	void Awake(){
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		} else {
			Destroy (this.gameObject);
		}
		currentScene = SceneManager.GetActiveScene ();
		AudioSource = GetComponent<AudioSource> ();
		AudioSource.ignoreListenerVolume = true;
		AudioSource.volume = PlayerPrefs.GetFloat ("MusicVolume", AudioSource.volume);
		AudioListener.volume = PlayerPrefs.GetFloat ("SFXVolume", AudioListener.volume);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentScene != SceneManager.GetActiveScene ()) {
			currentScene = SceneManager.GetActiveScene ();
			AudioListener.volume = PlayerPrefs.GetFloat ("SFXVolume", AudioListener.volume);
			if (GameObject.Find ("Sfx") != null) {
				sfxS = GameObject.Find ("Sfx").GetComponent<Slider> ();
				sfxS.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
				sfxS.value = PlayerPrefs.GetFloat ("SFXVolume", sfxS.value);
			}
			if (GameObject.Find ("Music") != null){
				musicS = GameObject.Find ("Music").GetComponent<Slider> ();
				musicS.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
				musicS.value = PlayerPrefs.GetFloat ("MusicVolume", musicS.value);
			}
		}

		if (currentScene.name == "MainMenu" && MusicStarted == false) {
			AudioSource.Stop ();
			AudioSource.clip = mainMenu;
			AudioSource.Play ();
			MusicStarted = true;
		}
		if (currentScene.name == "LevelSelect" && MusicStarted == true) {
			AudioSource.Stop ();
			AudioSource.clip = game;
			AudioSource.Play ();
			MusicStarted = false;
		}
		if (currentScene.name == "GameOver" && MusicStarted == false) {
			AudioSource.Stop ();
			AudioSource.clip = mainMenu;
			AudioSource.Play ();
			MusicStarted = true;
		}
	}

	public void ValueChangeCheck()
	{
		if (musicS != null) {
			PlayerPrefs.SetFloat ("MusicVolume", musicS.value);
			AudioSource.volume = musicS.value;
		}
		if (sfxS != null) {
			PlayerPrefs.SetFloat ("SFXVolume", sfxS.value);
			AudioListener.volume = sfxS.value;
		}
	}
}
