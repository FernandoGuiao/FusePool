﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {

	public GameObject pauseScreen;
	public GameObject leaderboardScreen;
	public GameObject iniScreen;
	public GameObject AskAdScreen;
	public GameObject TextWarningObj;
	public GameObject Music;
	public GameObject HTPScreen;

	//Reset The Scene
	public void Reset()
	{
		//gameObject.GetComponent<Ads>().SimpleAdShow();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	public void ToggleEndGameScreen()
	{
		GameObject.FindWithTag("GameController").GetComponent<Counter>().endGameScreen.SetActive(!GameObject.FindWithTag("GameController").GetComponent<Counter>().endGameScreen.activeSelf);
	}

	public void TogglePauseScreen()
	{
		gameObject.GetComponent<MenuControl>().pauseScreen.SetActive(!gameObject.GetComponent<MenuControl>().pauseScreen.activeSelf);
	}

	public void ToggleLeaderoardScreen()
	{
		gameObject.GetComponent<MenuControl>().leaderboardScreen.SetActive(!gameObject.GetComponent<MenuControl>().leaderboardScreen.activeSelf);
	}

	public void ToggleIniScreen()
	{
		iniScreen.SetActive(!iniScreen.activeSelf);
	}

	public void ToggleAskAdScreen()
	{
		AskAdScreen.SetActive(!AskAdScreen.activeSelf);
		print("ASKadscreen toggled");
	}

	public void DeactivateAskAdScreen()
	{
		AskAdScreen.SetActive(false);
		print("ASKadscreen deactivated");
	}

	public void DeactivateHowToPlayScreen()
	{
		HTPScreen.SetActive(false);
		print("HTPScreen deactivated");
	}

	public void CallTextWaring(string text,  Color color)
	{
		StartCoroutine(TextWarning(text, color));
		print("Txt warning call: " + text);
	}

	public void MuteMusic()
	{
		Music.GetComponent<AudioSource>().mute = !Music.GetComponent<AudioSource>().mute;
		print("Toggle Mute Music ");
	}


	public IEnumerator TextWarning(string text, Color color)
	{
		TextWarningObj.SetActive(true);
		TextWarningObj.GetComponent<Text>().color = color;
		TextWarningObj.GetComponent<Text>().text = text;
		print("Txt warning: " + text);
		
		float waitTime = 2.0f;
		yield return new WaitForSeconds(waitTime);
		TextWarningObj.SetActive(false);


	}

}
