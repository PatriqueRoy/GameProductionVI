using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCube : MonoBehaviour {

	public Transform laserPoint;
	public LineRenderer line;
	public Material white;
	public Material red;
	public Material blue;
	public Material green;
	public Material teal;
	public Material yellow;
	public Material magenta;

	private Ray ray;
	private RaycastHit hit;
	private RaycastHit UIhit;

	public GameObject crystal;
	public Rigidbody rb;
	private GameObject holder;

	public bool isActive = false;
	public bool isHit = false;
	private GameObject isHitObject;
	private bool once = false;

	public Camera cam;
	public bool display = false;
	private bool inTrigger = false;

	private Quaternion newRotation = Quaternion.identity;
	private int leftClicks = 1;
	public GameObject cube;
	private int rightClicks = 1;


	private GUIStyle style;

	private AudioSource AudioSource;
	public AudioClip uiSound;

	// Use this for initialization
	void Start () {
		AudioSource = GetComponent<AudioSource> ();
		AudioSource.clip = uiSound;

		holder = transform.parent.gameObject;
		crystal = holder.transform.Find ("Icosphere").gameObject;
		rb = crystal.GetComponent<Rigidbody> ();

		line = GetComponent<LineRenderer> ();
		line.material = white;

		style = new GUIStyle();
		style.fontSize = 25;
		style.normal.textColor = Color.white;
	}
	void Update(){
		if (cam) {
			ray = cam.ViewportPointToRay (new Vector3 (0.5F, 0.5F, 0));
		}
		if (inTrigger) {
			if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray, out UIhit)) {
				if (UIhit.transform.gameObject.name == "LeftArrow" && cube) {
					AudioSource.Play ();
					newRotation = Quaternion.Euler (new Vector3 (0, -90.0f * leftClicks, 0));
					leftClicks++;
					rightClicks--;
				}
				if (UIhit.transform.gameObject.name == "RightArrow" && cube) {
					AudioSource.Play ();
					newRotation = Quaternion.Euler (new Vector3 (0, 90.0f * rightClicks, 0));
					leftClicks--;
					rightClicks++;
				}
			}
		}

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (isActive) {
			rb.angularVelocity = new Vector3 (1, 1, 1);
			if (Physics.Raycast (laserPoint.position, -transform.right, out hit)) {
				line.enabled = true;
				line.SetPosition (0, laserPoint.position);
				line.SetPosition (1, hit.point);
				if (hit.transform.gameObject.name == "GoalCrystal") {
					if (transform.rotation.eulerAngles.y == 0) {
						hit.transform.gameObject.SendMessage ("OnRaycastHit", this.transform.gameObject);
					}
				}
				if (hit.transform.gameObject.tag == "CrystalFocus" && newRotation != null && transform.rotation.eulerAngles.y < newRotation.eulerAngles.y + 5.0f 
					|| hit.transform.gameObject.tag == "CrystalFocus" && newRotation == Quaternion.identity) {
					hit.transform.gameObject.GetComponentInParent<CrystalCube> ().isActive = true;
					hit.transform.gameObject.GetComponentInParent<CrystalCube> ().isHit = true;
					hit.transform.gameObject.GetComponentInParent<CrystalCube> ().once = false;
					isHitObject = hit.transform.gameObject;
				

					holder = isHitObject.transform.parent.gameObject;
					GameObject cryst = holder.transform.Find ("Icosphere").gameObject;
					if (cryst.tag == "Red") {
						if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == white || this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == red) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = red;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == blue) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = magenta;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == green) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = yellow;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == yellow) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = yellow;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == magenta) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = magenta;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == teal) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = white;
						}
					}
					if (cryst.tag == "Blue") {
						if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == white || this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == blue) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = blue;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == red) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = magenta;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == green) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = teal;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == yellow) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = white;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == magenta) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = magenta;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == teal) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = teal;
						}
					}
					if (cryst.tag == "Green") {
						if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == white || this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == green) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = green;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == blue) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = teal;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == red) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = yellow;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == yellow) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = yellow;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == magenta) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = white;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == teal) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = teal;
						}
					}
					if (cryst.tag == "White") {
						if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == white) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = white;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == blue) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = blue;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == red) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = red;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == green) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = green;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == teal) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = teal;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == yellow) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = yellow;
						} else if (this.transform.gameObject.GetComponentInParent<CrystalCube> ().line.sharedMaterial == magenta) {
							hit.transform.gameObject.GetComponentInParent<CrystalCube> ().line.material = magenta;
						}
					}
				} else if (isHitObject) {
					isHitObject.SendMessage ("onExit", isHitObject);
				} 
			}
		} else if (isHitObject && !once) {
			isHitObject.SendMessage ("onExit", isHitObject);
			once = true;
		} 
		if (cube) {
			cube.transform.rotation = Quaternion.Slerp (this.transform.rotation, newRotation, .1f);
		} 

	}

	void onExit(GameObject c){
		if (c.gameObject.GetComponent<CrystalCube> ().isHit) {
			c.GetComponent<CrystalCube> ().isActive = false;
			c.GetComponent<CrystalCube> ().line.enabled = false;
			c.GetComponent<CrystalCube> ().isHit = false;
			holder = c.transform.parent.gameObject;
			GameObject cryst = holder.transform.Find ("Icosphere").gameObject;
			cryst.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		}
	}

	void OnTriggerStay(Collider c){
		display = true;
		inTrigger = true;
		cube = this.gameObject;
	}

	void OnTriggerExit(Collider c){
		display = false;
		inTrigger = true;
		cube = null;
	}

	void OnGUI(){
		if (Physics.Raycast (ray, out UIhit) && display == true) {
			if (UIhit.transform.gameObject.name == "LeftArrow") {
				GUI.Label (new Rect (Screen.width / 2.1f, Screen.height / 2.5f, 200f, 200f), "Rotate focus to the left", style);
			}
			if (UIhit.transform.gameObject.name == "RightArrow") {
				GUI.Label (new Rect (Screen.width / 2.1f, Screen.height / 2.5f, 200f, 200f), "Rotate focus to the right", style);
			}
		}
	}
}
