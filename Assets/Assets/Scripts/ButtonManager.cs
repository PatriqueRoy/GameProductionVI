using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	private bool display = false;
	private bool inTrigger = false;
	private GUIStyle style;
	//public GameObject Puzzle1Button;
	public Material Blue;
	public Material Red;

	private AudioSource AudioSource;
	public AudioClip uiSound;

	// Use this for initialization
	void Start () {
		AudioSource = GetComponent<AudioSource> ();
		AudioSource.clip = uiSound;
		style = new GUIStyle();
		style.fontSize = 25;
		style.normal.textColor = Color.white;
	}

	// Update is called once per frame
	void Update () {
		if (inTrigger) {
			if (Input.GetMouseButtonDown(0)) {
				AudioSource.Play ();
				GameObject[] bridge = GameObject.FindGameObjectsWithTag ("Puzzle1Bridge");
				for (int j = 0; j < bridge.Length; j++) {
					bridge [j].GetComponentInChildren<Renderer> ().material = Blue;
					foreach( Transform child in bridge[j].transform){
						child.tag = "Floor";
					}
				}
			}
		}
	}
	void OnTriggerStay(Collider c){
		if (this.tag == "Puzzle1Button"){
			display = true;
			inTrigger = true;
		}
	}
	void OnTriggerExit(Collider c){
		display = false;
		inTrigger = false;
	}

	void OnGUI(){
		if (display == true) {
			GUI.Label(new Rect(Screen.width / 2.2f, Screen.height / 2.5f, 200f, 200f), "'Left Click' to Activate", style);
		}
	}
}
