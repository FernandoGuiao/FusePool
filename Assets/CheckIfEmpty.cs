using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfEmpty : MonoBehaviour {

	void Update () {
		string playerName = GameObject.FindWithTag("PlayerNameInput").GetComponent<Text>().text;
		if (playerName == "")
		{
			GameObject.FindWithTag("NewHiScoreButton").GetComponent<Button>().interactable = false;
		}
	}
}
