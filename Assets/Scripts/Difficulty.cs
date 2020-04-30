using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Difficulty : MonoBehaviour {

	public GameObject iniScreen;
	// Use this for initialization
	public void NormalDiff () {
		GameObject.FindWithTag("GameController").GetComponent<Counter>().difficultyAdd = 1;
		iniScreen.SetActive(false);
	}
	public void HardDiff () {
		GameObject.FindWithTag("GameController").GetComponent<Counter>().difficultyAdd = 0;
		GameObject.FindGameObjectWithTag("HardFlag").GetComponent<Image>().enabled = true;
		iniScreen.SetActive(false);
	}
	

}
