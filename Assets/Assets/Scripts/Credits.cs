using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
	private AudioSource AudioSource;
	public AudioClip uiSound;

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
