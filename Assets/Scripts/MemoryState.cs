using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MemoryState : MonoBehaviour
{

	int ballnumber = 0;



	public void SaveGame()
	{
		var bestscore = 0;

		if (PlayerPrefs.HasKey("SaveBest"))
		{
			bestscore = PlayerPrefs.GetInt("SaveBest");
		}

		PlayerPrefs.DeleteAll();

		GameObject[] balls0 = GameObject.FindGameObjectsWithTag("0");
		foreach (GameObject ball in balls0)
		{ SaveBall(ball); }

		GameObject[] balls1 = GameObject.FindGameObjectsWithTag("1");
		foreach (GameObject ball in balls1)
		{ SaveBall(ball); }

		GameObject[] balls2 = GameObject.FindGameObjectsWithTag("2");
		foreach (GameObject ball in balls2)
		{ SaveBall(ball); }

		GameObject[] balls3 = GameObject.FindGameObjectsWithTag("3");
		foreach (GameObject ball in balls3)
		{ SaveBall(ball); }

		GameObject[] balls4 = GameObject.FindGameObjectsWithTag("4");
		foreach (GameObject ball in balls4)
		{ SaveBall(ball); }

		GameObject[] balls5 = GameObject.FindGameObjectsWithTag("5");
		foreach (GameObject ball in balls5)
		{ SaveBall(ball); }

		GameObject[] balls6 = GameObject.FindGameObjectsWithTag("6");
		foreach (GameObject ball in balls6)
		{ SaveBall(ball); }

		GameObject[] balls7 = GameObject.FindGameObjectsWithTag("7");
		foreach (GameObject ball in balls7)
		{ SaveBall(ball); }

		GameObject[] balls8 = GameObject.FindGameObjectsWithTag("8");
		foreach (GameObject ball in balls8)
		{ SaveBall(ball); }

		GameObject[] balls9 = GameObject.FindGameObjectsWithTag("9");
		foreach (GameObject ball in balls9)
		{ SaveBall(ball); }


		//pontuação
		PlayerPrefs.SetInt("SavedScore", gameObject.GetComponent<Counter>().fusions);
		//bolar maximas e na mesa
		PlayerPrefs.SetFloat("MaxBalls", gameObject.GetComponent<Counter>().maxBalls);
		PlayerPrefs.SetInt("BallCount", gameObject.GetComponent<Counter>().ballCount);
		//dificuldade
		PlayerPrefs.SetInt("Difficulty", gameObject.GetComponent<Counter>().difficultyAdd);

		//Reward
		PlayerPrefs.SetInt("AdReward", gameObject.GetComponent<Counter>().rewardAdd);
		if (gameObject.GetComponent<Counter>().hadReward)
		{ 
		PlayerPrefs.SetInt("HadReward", 1);
		}
		else
		PlayerPrefs.SetInt("HadReward", 0);

		// é última bola
		print("is last ball PRINT    =>   " + gameObject.GetComponent<Counter>().isLastBall);
		if (gameObject.GetComponent<Counter>().isLastBall == true)
		{
			print("2 is last ball PRINT    =>   " + gameObject.GetComponent<Counter>().isLastBall);
			PlayerPrefs.SetInt("isLastBall", 1);
		}
		//se tiver passado da ultima bola
		if (gameObject.GetComponent<Counter>().lockMaxBalls == true)
		{
			print("2 is last ball PRINT    =>   " + gameObject.GetComponent<Counter>().lockMaxBalls);
			PlayerPrefs.SetInt("LockMaxBalls", 1);
		}



		PlayerPrefs.SetInt("SaveBest", bestscore);
		ballnumber = 0;
		PlayerPrefs.Save();
		print("Game Saved");
		gameObject.GetComponent<MenuControl>().CallTextWaring("Game Saved!", Color.green);
	}


	void SaveBall(GameObject ball)
	{

		//posição
		PlayerPrefs.SetFloat("ball" + ballnumber + "PosX", ball.transform.position.x);
		PlayerPrefs.SetFloat("ball" + ballnumber + "PosY", ball.transform.position.y);
		PlayerPrefs.SetFloat("ball" + ballnumber + "PosZ", ball.transform.position.z);
		//rotação
		PlayerPrefs.SetFloat("ball" + ballnumber + "RotX", ball.transform.localRotation.x);
		PlayerPrefs.SetFloat("ball" + ballnumber + "RotY", ball.transform.localRotation.y);
		PlayerPrefs.SetFloat("ball" + ballnumber + "RotZ", ball.transform.localRotation.z);
		PlayerPrefs.SetFloat("ball" + ballnumber + "RotW", ball.transform.localRotation.w);
		//velocidade
		PlayerPrefs.SetFloat("ball" + ballnumber + "VelX", ball.GetComponent<Rigidbody>().velocity.x);
		PlayerPrefs.SetFloat("ball" + ballnumber + "VelY", ball.GetComponent<Rigidbody>().velocity.y);
		PlayerPrefs.SetFloat("ball" + ballnumber + "VelZ", ball.GetComponent<Rigidbody>().velocity.z);
		//tag
		PlayerPrefs.SetString("ball" + ballnumber + "Tag", ball.tag);

		ballnumber++;


	}

	public void LoadGame()
	{
		//pause
		Time.timeScale = 0;


		// delete balls
		GameObject[] balls0 = GameObject.FindGameObjectsWithTag("0");
		foreach (GameObject ball in balls0)
		{ Destroy(ball); }
		GameObject[] balls1 = GameObject.FindGameObjectsWithTag("1");
		foreach (GameObject ball in balls1)
		{ Destroy(ball); }
		GameObject[] ballsActive = GameObject.FindGameObjectsWithTag("Active");
		foreach (GameObject ball in balls0)
		{ Destroy(ball); }

		//load balls
		int balls = 0;
		while (balls >= 0)
		{

			if (PlayerPrefs.HasKey("ball" + balls + "Tag"))
			{
				GameObject clone;
				clone = Instantiate(gameObject.GetComponent<LaunchBall>().ballPrefabs[int.Parse(PlayerPrefs.GetString("ball" + balls + "Tag"))], new Vector3(PlayerPrefs.GetFloat("ball" + balls + "PosX"), PlayerPrefs.GetFloat("ball" + balls + "PosY"), PlayerPrefs.GetFloat("ball" + balls + "PosZ")), new Quaternion(PlayerPrefs.GetFloat("ball" + balls + "RotX"), PlayerPrefs.GetFloat("ball" + balls + "RotY"), PlayerPrefs.GetFloat("ball" + balls + "RotZ"), PlayerPrefs.GetFloat("ball" + balls + "RotW")));
				clone.GetComponent<Rigidbody>().velocity = new Vector3(PlayerPrefs.GetFloat("ball" + balls + "VelX"), PlayerPrefs.GetFloat("ball" + balls + "VelY"), PlayerPrefs.GetFloat("ball" + balls + "VelZ"));
				if (clone.tag == "Spawning") { clone.tag = "0"; }

				balls++;
			}

			else { break; }
		}




		if (PlayerPrefs.GetInt("LockMaxBalls") == 1)
		{
			gameObject.GetComponent<Counter>().lockMaxBalls = true;
		}

		gameObject.GetComponent<Counter>().difficultyAdd = PlayerPrefs.GetInt("Difficulty");
		gameObject.GetComponent<Counter>().ballCount = PlayerPrefs.GetInt("BallCount");
		gameObject.GetComponent<Counter>().maxBalls = PlayerPrefs.GetFloat("MaxBalls");

		//reward
		gameObject.GetComponent<Counter>().rewardAdd = PlayerPrefs.GetInt("AdReward");
		if (PlayerPrefs.GetInt("HadReward") == 1)
		{
			gameObject.GetComponent<Counter>().hadReward = true;
		}
		else
			gameObject.GetComponent<Counter>().hadReward = false;


		gameObject.GetComponent<Counter>().fusions = PlayerPrefs.GetInt("SavedScore");

		if (PlayerPrefs.GetInt("isLastBall") == 1)
		{
			gameObject.GetComponent<Counter>().isLastBall = true;
		}

		if (PlayerPrefs.GetInt("Difficulty") == 0)
		{
			GameObject.FindGameObjectWithTag("HardFlag").GetComponent<Image>().enabled = true;
		}


		gameObject.GetComponent<MenuControl>().ToggleIniScreen();
		gameObject.GetComponent<LaunchBall>().Spawn();


		Time.timeScale = 1;

	}

	public void DelGame()
	{
		if (PlayerPrefs.HasKey("Difficulty"))
		{
			var bestscore = 0;
			if (PlayerPrefs.HasKey("SaveBest"))
			{
				bestscore = PlayerPrefs.GetInt("SaveBest");
			}

			PlayerPrefs.DeleteAll();

			PlayerPrefs.SetInt("SaveBest", bestscore);
			ballnumber = 0;
			PlayerPrefs.Save();
			print("Game Deleted");
			gameObject.GetComponent<MenuControl>().CallTextWaring("Save Deleted", Color.red);

		}
	}
}
