using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLevel1Puzzle : MonoBehaviour {

	public GameObject ball;
	private GameObject instance;
	public Transform ballSpawn;
	public Camera cam; 
	private bool display = false;

	private Ray ray;
	private RaycastHit hit;

	private bool LeftPressed = false;
	private bool RightPressed = false;

	private bool inTrigger = false;
	private GUIStyle style;

	private AudioSource AudioSource;
	public AudioClip uiSound;

	void Start(){
		AudioSource = GetComponent<AudioSource> ();
		AudioSource.clip = uiSound;
		style = new GUIStyle();
		style.fontSize = 25;
		style.normal.textColor = Color.white;
	}
	// Update is called once per frame
	void Update () {
	 	ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

		if (inTrigger) {
			if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out hit)) {
				if (hit.transform.gameObject.name == "StartButton") {
					AudioSource.Play ();
					if (instance) {
						Destroy (instance);
						instance = Instantiate(ball, ballSpawn.position, ballSpawn.rotation) as GameObject;
						LeftPressed = false;
						RightPressed = false;
					} else {
						instance = Instantiate(ball, ballSpawn.position, ballSpawn.rotation) as GameObject;
					}

					Rigidbody rb = instance.GetComponent<Rigidbody> ();
					rb.AddForce (Vector3.right * -100.0f);

				}
				if (hit.transform.gameObject.name == "LeftArrow" && LeftPressed == false && RightPressed == false) {
					Rigidbody rb = instance.GetComponent<Rigidbody> ();
					rb.AddForce (Vector3.forward * 300.0f);
					LeftPressed = true;
					RightPressed = false;
					AudioSource.Play ();
				}else if(hit.transform.gameObject.name == "LeftArrow" && LeftPressed == false && RightPressed == true){
					Rigidbody rb = instance.GetComponent<Rigidbody> ();
					rb.AddForce (Vector3.forward * 400.0f);
					LeftPressed = true;
					RightPressed = false;
					AudioSource.Play ();
				}
				if (hit.transform.gameObject.name == "RightArrow" && LeftPressed == false && RightPressed == false) {
					Rigidbody rb = instance.GetComponent<Rigidbody> ();
					rb.AddForce (Vector3.forward * -300.0f);
					LeftPressed = false;
					RightPressed = true;
					AudioSource.Play ();
				}else if(hit.transform.gameObject.name == "RightArrow" && LeftPressed == true && RightPressed == false){
					Rigidbody rb = instance.GetComponent<Rigidbody> ();
					rb.AddForce (Vector3.forward * -400.0f);
					LeftPressed = false;
					RightPressed = true;
					AudioSource.Play ();
				}
			}
		}
	}

	void OnTriggerStay(Collider c){
		display = true;
		inTrigger = true;
	}

	void OnTriggerExit(Collider c){
		display = false;
		inTrigger = true;
	}

	void OnGUI(){
		if (Physics.Raycast (ray, out hit) && display == true) {
			if (hit.transform.gameObject.name == "StartButton") {
				GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.5f, 200f, 200f), "Launch Ball", style);
			}
			if (hit.transform.gameObject.name == "LeftArrow") {
				GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.5f, 200f, 200f), "Push Ball to the left", style);
			}
			if (hit.transform.gameObject.name == "RightArrow") {
				GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.5f, 200f, 200f), "Push Ball to the right", style);
			}
		}
	}
}
