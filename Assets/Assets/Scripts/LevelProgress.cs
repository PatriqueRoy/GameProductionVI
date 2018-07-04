using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour {

	private static bool created = false;
	public int zone = 1;

	private float CompletionTime;
	public Text time;
	public Text bestTime;
	public Canvas Timer;
	public Text TimerText;

	private GameObject GreenGate;
	private GameObject GreenLight;
	private GameObject RedGate;
	private GameObject RedLight;

	public GameObject changer;

	private Scene currentScene;

	void Awake(){
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			DontDestroyOnLoad (Timer);
			created = true;
		} else {
			Destroy (this.gameObject);
			Destroy (Timer.gameObject);
		}
		if (PlayerPrefs.GetFloat ("BestTime") < 9999.0f) {
			//do nothing
		} else {
			PlayerPrefs.SetFloat ("BestTime", 9999.0f);
		}

		currentScene = SceneManager.GetActiveScene ();
		GreenGate = GameObject.Find ("GREENGATE");
		GreenLight = GameObject.Find ("GreenOn");
		RedGate = GameObject.Find ("REDGATE");
		RedLight = GameObject.Find ("RedOn");

		changer = GameObject.Find ("LevelChanger");

	}
		
	void Update () {
		if (currentScene != SceneManager.GetActiveScene ()) {
			currentScene = SceneManager.GetActiveScene ();

			GreenGate = GameObject.Find ("GREENGATE");
			GreenLight = GameObject.Find ("GreenOn");
			RedGate = GameObject.Find ("REDGATE");
			RedLight = GameObject.Find ("RedOn");

			changer = GameObject.Find ("LevelChanger");
		}
		if (changer != null) {
			if (changer.GetComponent<LevelManager> ().triggered == true && currentScene.name == "BlueLevel3") {
				zone = 2;
			}
			if (changer.GetComponent<LevelManager> ().triggered == true && currentScene.name == "GreenLevel3") {
				zone = 3;
			}
		}
		if (zone == 2) {
			if (GreenGate != null) {
				GreenGate.SetActive (false);
				GreenLight.GetComponent<Light> ().enabled = true;
			}
		}
		if (zone == 3) {
			if (GreenGate != null && RedGate != null) {
				GreenGate.SetActive (false);
				RedGate.SetActive (false);
				GreenLight.GetComponent<Light> ().enabled = true;
				RedLight.GetComponent<Light> ().enabled = true;
			}
		}
	}
	void FixedUpdate(){
		if (currentScene.name != "GameOver") {
			CompletionTime += Time.fixedDeltaTime;
			TimerText.text = Mathf.RoundToInt (CompletionTime).ToString ();

		} else {
			Timer.enabled = false;
			time = GameObject.Find ("CurrentTime").GetComponent<Text>();
			bestTime = GameObject.Find ("BestTime").GetComponent<Text>();

			time.text = Mathf.RoundToInt (CompletionTime).ToString() + " Seconds";

			if (CompletionTime < PlayerPrefs.GetFloat ("BestTime")) {
				PlayerPrefs.SetFloat ("BestTime", CompletionTime);
			}
			if (PlayerPrefs.GetFloat ("BestTime") == 0) {
				PlayerPrefs.SetFloat ("BestTime", CompletionTime);
			}
			bestTime.text =  Mathf.RoundToInt (PlayerPrefs.GetFloat ("BestTime")).ToString() + " Seconds";
		}
		if(currentScene.name == "MainMenu"){
			Timer.enabled = false;
			CompletionTime = 0.0f;
			zone = 1;
		}
		if(currentScene.name == "LevelSelect"){
			Timer.enabled = true;
		}

	}

}
