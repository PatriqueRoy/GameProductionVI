using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLevel1Puzzle : MonoBehaviour {
	
	public Material Blue;
	public Material Red;

	public GameObject[] Left;
	public GameObject[] Right;
	// Use this for initialization
	void Start () {
		StartCoroutine("PuzzleChange");
	}
	
	IEnumerator PuzzleChange(){
		while (true) {
			for (int i = 0; i < Left.Length; i++) {
				Left [i].GetComponentInChildren<Renderer> ().material = Red;
				Left [i].transform.tag = "Red";
				Right [i].GetComponentInChildren<Renderer> ().material = Red;
				Right [i].transform.tag = "Red";
				yield return new WaitForSeconds(0.8f);
			}
			for (int i = 0; i < Left.Length; i++) {
				Left [i].GetComponentInChildren<Renderer> ().material = Blue;
				Left [i].transform.tag = "Floor";
				Right [i].GetComponentInChildren<Renderer> ().material = Blue;
				Right [i].transform.tag = "Floor";
				yield return new WaitForSeconds(0.8f);
			}
		}
	}
}
