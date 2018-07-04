using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPuzzleGoal : MonoBehaviour {
	public Material BlueBeam;
	public Material RedBeam;
	public Material GreenBeam;
	public Material TealBeam;
	public Material YellowBeam;
	public Material MagentaBeam;
	public Material blue;
	public Material red;
	public Material green;
	public Material teal;
	public Material magenta;
	public Material yellow;
	public GameObject Gate;

	private bool start = false;
	private Vector3 newLocation;

	public void OnRaycastHit(GameObject c){
		if (c.gameObject.GetComponent<CrystalCube>().line.sharedMaterial == BlueBeam && this.gameObject.GetComponent<Renderer>().sharedMaterial == blue ||
			c.gameObject.GetComponent<CrystalCube>().line.sharedMaterial == RedBeam && this.gameObject.GetComponent<Renderer>().sharedMaterial == red ||
			c.gameObject.GetComponent<CrystalCube>().line.sharedMaterial == GreenBeam && this.gameObject.GetComponent<Renderer>().sharedMaterial == green ||
			c.gameObject.GetComponent<CrystalCube>().line.sharedMaterial == TealBeam && this.gameObject.GetComponent<Renderer>().sharedMaterial == teal ||
			c.gameObject.GetComponent<CrystalCube>().line.sharedMaterial == YellowBeam && this.gameObject.GetComponent<Renderer>().sharedMaterial == yellow ||
			c.gameObject.GetComponent<CrystalCube>().line.sharedMaterial == MagentaBeam && this.gameObject.GetComponent<Renderer>().sharedMaterial == magenta ) {
			Win ();
		}
	}

	void Win(){
		start = true;
		this.gameObject.GetComponent<Rigidbody> ().angularVelocity = Vector3.one;
		Destroy (Gate, 1.0f);
	}

	void Start(){
		newLocation = transform.position + new Vector3 (0, 1.0f, 0); 
	}
	void FixedUpdate(){
		if (start) {
			transform.position = Vector3.Slerp (transform.position, newLocation, 0.01f);
		}
	}
}
