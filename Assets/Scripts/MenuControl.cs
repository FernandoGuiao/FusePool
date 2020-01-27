﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

	public GameObject pauseScreen;

	//Reset The Scene
	public void Reset ()
	{
		//gameObject.GetComponent<Ads>().SimpleAdShow();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	public void ToggleEndGameScreen ()
	{
		GameObject.FindWithTag("GameController").GetComponent<Counter>().endGameScreen.SetActive(!GameObject.FindWithTag("GameController").GetComponent<Counter>().endGameScreen.activeSelf);
	}

	public void TogglePauseScreen ()
	{
		gameObject.GetComponent<MenuControl>().pauseScreen.SetActive(!gameObject.GetComponent<MenuControl>().pauseScreen.activeSelf);
	}


}
