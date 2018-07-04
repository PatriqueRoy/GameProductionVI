using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

	private bool locked;
	CursorLockMode wantedMode;
	Scene currentScene;

	public GameObject look;
	public Canvas pauseMenu;

	private AudioSource AudioSource;
	public AudioClip uiSound;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ();
		AudioSource = GetComponent<AudioSource> ();
		AudioSource.clip = uiSound;
		if (currentScene.name != "MainMenu" || currentScene.name != "Settings" || currentScene.name != "GameOver") {
			Cursor.lockState = wantedMode = CursorLockMode.Locked;
			locked = true;
			if (pauseMenu) {
				pauseMenu.gameObject.SetActive (false);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		MouseLock ();

		if (currentScene.name != "MainMenu" || currentScene.name != "Settings" || currentScene.name != "GameOver"){
			if(Input.GetKeyDown(KeyCode.P)){
				if (pauseMenu) {
					pauseMenu.gameObject.SetActive (true);
				}
				look.GetComponent<MouseLook> ().enabled = false;
				Time.timeScale = 0;

				Button btnR = GameObject.Find("Resume").GetComponent<Button> ();
				btnR.onClick.AddListener (ResumeOnClick);
				if (GameObject.Find ("Select")) {
					Button btnS = GameObject.Find ("Select").GetComponent<Button> ();
					btnS.onClick.AddListener (SelectOnClick);
				}
				Button btnQ = GameObject.Find("Quit").GetComponent<Button> ();
				btnQ.onClick.AddListener (MenuOnClick);
			}
		}
	}

	void MenuOnClick(){
		AudioSource.Play ();
		StartCoroutine ("MenuLoad");
	}
	IEnumerator MenuLoad(){
		Time.timeScale = 1;
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("MainMenu");
	}

	void SelectOnClick(){
		AudioSource.Play ();
		StartCoroutine ("SelectLoad");
	}
	IEnumerator SelectLoad(){
		Time.timeScale = 1;
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("LevelSelect");
	}

	void ResumeOnClick(){
		AudioSource.Play ();
		StartCoroutine ("ResumeLoad");
	}
	IEnumerator ResumeLoad(){
		Time.timeScale = 1;
		yield return new WaitForSeconds (0.2f);
		if (pauseMenu) {
			pauseMenu.gameObject.SetActive (false);
		}
		look.GetComponent<MouseLook> ().enabled = true;
		wantedMode = CursorLockMode.Locked;
		locked = true;
	}

	void MouseLock(){
		if (currentScene.name == "MainMenu" || currentScene.name == "GameOver" || currentScene.name == "Win") {
			Cursor.lockState = wantedMode;
			wantedMode = CursorLockMode.None;
		}
		if (currentScene.name != "MainMenu" || currentScene.name != "Settings") {
			Cursor.lockState = wantedMode;
			if (Input.GetKeyDown (KeyCode.P) && locked == true || Input.GetKeyDown (KeyCode.Escape) && locked == true) {
				wantedMode = CursorLockMode.None;
				locked = false;
			} 
			if (Input.GetMouseButtonDown (0) && locked == false && pauseMenu.gameObject.activeSelf == false) {
				wantedMode = CursorLockMode.Locked;
				locked = true;
			}
		}
	}

	void OnGUI(){
		if (currentScene.name != "MainMenu" && wantedMode != CursorLockMode.None || currentScene.name != "Settings" && wantedMode != CursorLockMode.None) {
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 10, 10), "");
		}
	}
}
