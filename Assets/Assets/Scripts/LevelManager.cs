using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public bool triggered = false;
	Scene currentScene;
	private AudioSource AudioSource;
	public AudioClip WinSound;

	void Start () {
		AudioSource = GetComponent<AudioSource> ();
		AudioSource.clip = WinSound;
		AudioSource.ignoreListenerPause = true;
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			currentScene = SceneManager.GetActiveScene ();
			if (currentScene.name == "BlueLevel3" || currentScene.name == "GreenLevel3") {
				triggered = true;
			}

			if (currentScene.name == "LevelSelect") {
				Invoke ("LevelSceneChange", 1);
			} else {
				AudioListener.pause = true;
				AudioSource.Play ();
				Invoke ("SceneChange", 3);
			}


		}
	}
	void LevelSceneChange(){
		currentScene = SceneManager.GetActiveScene ();
		if (currentScene.name == "LevelSelect" && this.gameObject.name == "LevelChangerBlue") {
			SceneManager.LoadScene("BlueLevel");
		}
		if (currentScene.name == "LevelSelect" && this.gameObject.name == "LevelChangerGreen") {
			SceneManager.LoadScene("GreenLevel");
		}
		if (currentScene.name == "LevelSelect" && this.gameObject.name == "LevelChangerRed") {
			SceneManager.LoadScene("RedLevel");
		}
	}
	void SceneChange(){
		currentScene = SceneManager.GetActiveScene ();
		if (currentScene.name == "BlueLevel") {
			AudioListener.pause = false;
			SceneManager.LoadScene("BlueLevel2");
		}
		if (currentScene.name == "BlueLevel2") {
			AudioListener.pause = false;
			SceneManager.LoadScene("BlueLevel3");
		}
		if (currentScene.name == "BlueLevel3") {
			AudioListener.pause = false;
			SceneManager.LoadScene("LevelSelect");
		}
		if (currentScene.name == "GreenLevel") {
			AudioListener.pause = false;
			SceneManager.LoadScene("GreenLevel2");
		}
		if (currentScene.name == "GreenLevel2") {
			AudioListener.pause = false;
			SceneManager.LoadScene("GreenLevel3");
		}
		if (currentScene.name == "GreenLevel3") {
			AudioListener.pause = false;
			SceneManager.LoadScene("LevelSelect");
		}
		if (currentScene.name == "RedLevel") {
			AudioListener.pause = false;
			SceneManager.LoadScene("RedLevel2");
		}
		if (currentScene.name == "RedLevel2") {
			AudioListener.pause = false;
			SceneManager.LoadScene("RedLevel3");
		}
		if (currentScene.name == "RedLevel3") {
			AudioListener.pause = false;
			SceneManager.LoadScene("GameOver");
		}
	}
}
