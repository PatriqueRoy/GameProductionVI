using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourGateControl : MonoBehaviour {

	public Material Blue;
	public Material Red;
	public Material Green;
	public Material Teal;
	public Material Magenta;
	public Material Yellow;
	public Material White;





	void OnTriggerEnter(Collider c){
		if (this.gameObject.tag == "GreenPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Green || this.gameObject.tag == "GreenPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == White) {
			c.gameObject.GetComponent<Renderer> ().material = Green;
			c.gameObject.layer = 11;
		}
		if (this.gameObject.tag == "GreenPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Magenta) {
			c.gameObject.GetComponent<Renderer> ().material = White;
			c.gameObject.layer = 0;
		}
		if (this.gameObject.tag == "GreenPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Red) {
			c.gameObject.GetComponent<Renderer> ().material = Yellow;
			c.gameObject.layer = 14;
		}
		if (this.gameObject.tag == "GreenPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Blue) {
			c.gameObject.GetComponent<Renderer> ().material = Teal;
			c.gameObject.layer = 12;
		}


		if (this.gameObject.tag == "BluePoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Blue || this.gameObject.tag == "BluePoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == White) {
			c.gameObject.GetComponent<Renderer> ().material = Blue;
			c.gameObject.layer = 10;
		}
		if (this.gameObject.tag == "BluePoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Yellow) {
			c.gameObject.GetComponent<Renderer> ().material = White;
			c.gameObject.layer = 0;
		}
		if (this.gameObject.tag == "BluePoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Red) {
			c.gameObject.GetComponent<Renderer> ().material = Magenta;
			c.gameObject.layer = 13;
		}
		if (this.gameObject.tag == "BluePoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Green) {
			c.gameObject.GetComponent<Renderer> ().material = Teal;
			c.gameObject.layer = 12;
		}



		if (this.gameObject.tag == "RedPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Red || this.gameObject.tag == "RedPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == White) {
			c.gameObject.GetComponent<Renderer> ().material = Red;
			c.gameObject.layer = 9;
		}
		if (this.gameObject.tag == "RedPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Teal) {
			c.gameObject.GetComponent<Renderer> ().material = White;
			c.gameObject.layer = 0;
		}
		if (this.gameObject.tag == "RedPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Green) {
			c.gameObject.GetComponent<Renderer> ().material = Yellow;
			c.gameObject.layer = 14;
		}
		if (this.gameObject.tag == "RedPoint" && c.gameObject.GetComponent<Renderer> ().sharedMaterial == Blue) {
			c.gameObject.GetComponent<Renderer> ().material = Magenta;
			c.gameObject.layer = 13;
		}

	}
}
