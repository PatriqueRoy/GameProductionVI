using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueLevel2Puzzle : MonoBehaviour {
	public Material Blue;
	public Material Red;
	public Material Green;
	public Material Yellow;
	public Material Teal;
	public Material Magenta;

	public GameObject[] first;

	Scene currentScene;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ();
		StartCoroutine("PuzzleChange");
	}
	
	IEnumerator PuzzleChange(){
		while (true) {
			if (currentScene.name == "BlueLevel2") {
				yield return new WaitForSeconds(1f);
				for (int i = 0; i < first.Length; i++) {
					if (first [i].transform.tag == "Green") {
						first [i].GetComponent<Renderer> ().material = Blue;
						first [i].transform.tag = "Floor";
					} else if (first [i].transform.tag == "Floor") {
						first [i].GetComponent<Renderer> ().material = Green;
						first [i].transform.tag = "Green";
					}
				}
			}if (currentScene.name == "BlueLevel3") {
				yield return new WaitForSeconds(2f);
				for (int i = 0; i < first.Length; i++) {
					if (first [i].GetComponent<Renderer> ().sharedMaterial == Green) {
						first [i].GetComponent<Renderer> ().material = Red;
						first [i].transform.tag = "Red";
					} else if (first [i].GetComponent<Renderer> ().sharedMaterial == Blue) {
						first [i].GetComponent<Renderer> ().material = Green;
						first [i].transform.tag = "Green";
					}else if (first [i].GetComponent<Renderer> ().sharedMaterial == Red) {
						first [i].GetComponent<Renderer> ().material = Blue;
						first [i].transform.tag = "Floor";
					}
				}
			}
		}
	}
}
