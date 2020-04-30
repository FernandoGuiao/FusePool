using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class checkCanLoad : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		print("start checkcanload     =>  " + PlayerPrefs.GetInt("isLastBall"));
		if (PlayerPrefs.GetInt("isLastBall") == 1)
		{
			print("start checkcanload filter");

			gameObject.GetComponentInChildren<Text>().text = "Can't Load Last Balls";
			gameObject.GetComponentInChildren<Text>().fontSize = 56;
			gameObject.GetComponent<Button>().interactable = false;

		}




		if (!PlayerPrefs.HasKey("MaxBalls"))
		{
			gameObject.GetComponentInChildren<Text>().text = "No Game To Load";
			gameObject.GetComponentInChildren<Text>().fontSize = 56;
			gameObject.GetComponent<Button>().interactable = false;
		}


	}
	

}
