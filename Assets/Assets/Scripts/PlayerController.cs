using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private float speed = 4.0f;
	private float JumpSpeed = 5.0f;
	public bool isGrounded;
	private Rigidbody rb;

	private Vector3 movement;
	private float moveHorizontal;
	private float moveVertical;
	private float Jump;
	private bool jumpRequest;

	public Transform Checkpoint0;
	public Transform Checkpoint1;
	public Transform Checkpoint2;
	private Vector3 CCheckpoint;

	private AudioSource AudioSource;
	public AudioClip jump;
	public AudioClip died;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		CCheckpoint = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		AudioSource = GetComponent<AudioSource> ();
	}

	void Update(){
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		if (isGrounded == true && Input.GetButtonDown("Jump")) {
			jumpRequest = true;
			isGrounded = false;
			AudioSource.PlayOneShot (jump);
		}
		//sprint function, disabled for now
		/*
		if (Input.GetKey (KeyCode.LeftShift)) {
			movement = new Vector3 (moveHorizontal / 1.1f, 0.0f, moveVertical * 2.0f);
		} else {
			movement = new Vector3 (moveHorizontal / 1.1f, 0.0f, moveVertical);
		}*/
		movement = new Vector3 (moveHorizontal / 1.1f, 0.0f, moveVertical);
	}
	void FixedUpdate ()
	{
		if (jumpRequest) {
			rb.AddRelativeForce (Vector3.up * JumpSpeed, ForceMode.Impulse);
			isGrounded = false;
			jumpRequest = false;
		}

		rb.AddRelativeForce (movement * speed, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Floor") {
			isGrounded = true;
		}
	}
	void OnCollisionStay(Collision c){
		if (c.gameObject.tag == "Red" || c.gameObject.tag == "Green") {
			this.transform.position = CCheckpoint;
			AudioSource.PlayOneShot (died);
		}
	}
}
