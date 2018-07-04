using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPuzzleGoal : MonoBehaviour {
	public Material Blue;
	public Material Red;
	public Material Green;
	public Material Teal;
	public Material Magenta;
	public Material Yellow;

	private Material winningColor;

	public GameObject Gate;

	void OnTriggerEnter(Collider c){
		if (c.gameObject.GetComponent<Renderer> ().sharedMaterial == Blue) {
			winningColor = Blue;
		}
		if (c.gameObject.GetComponent<Renderer> ().sharedMaterial == Red) {
			winningColor = Red;
		}
		if (c.gameObject.GetComponent<Renderer> ().sharedMaterial == Green) {
			winningColor = Green;
		}
		if (c.gameObject.GetComponent<Renderer> ().sharedMaterial == Teal) {
			winningColor = Teal;
		}
		if (c.gameObject.GetComponent<Renderer> ().sharedMaterial == Magenta) {
			winningColor = Magenta;
		}
		if (c.gameObject.GetComponent<Renderer> ().sharedMaterial == Yellow) {
			winningColor = Yellow;
		}
		Invoke ("Win",1.0f);
	}

	void Win(){
		this.gameObject.GetComponent<Renderer> ().material = winningColor;
		Destroy (Gate);
	}
}
