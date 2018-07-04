using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
	private AudioSource AudioSource;
	public AudioClip uiSound;

	// Use this for initialization
	void Start () {
		AudioSource = GetComponent<AudioSource> ();
		AudioSource.clip = uiSound;
		Button btnR = GameObject.Find ("Return").GetComponent<Button> ();
		btnR.onClick.AddListener (ReturnOnClick);
	}
	
	void ReturnOnClick(){
		AudioSource.Play ();
		StartCoroutine ("ReturnLoad");
	}
	IEnumerator ReturnLoad(){
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("MainMenu");
	}
}
