using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSave : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

		var bestscore = 0;

		if (PlayerPrefs.HasKey("SaveBest"))
		{
			bestscore = PlayerPrefs.GetInt("SaveBest");
		}

		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("SaveBest", bestscore);

	}

}