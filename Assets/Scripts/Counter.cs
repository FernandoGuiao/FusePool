using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Counter : MonoBehaviour {


	public int ballCount;
	public int fusions;
	public int timerLoseDefault;
	float timerLose;
	bool isWaiting;
	public bool isLastBall;
	public float maxBalls;
	public GameObject endGameScreen;
	public GameObject fillBar;
	public int difficultyAdd;
	public bool lockMaxBalls;
	public GameObject loseScreen;
	public GameObject NewHiScoreScreen;
	public GameObject maxBallsFireworks;
	private float lastMaxBalls;
	public bool newHiScore;
	public string playerName;


	dreamloLeaderBoard dl;

	void Start()
	{
		maxBalls = GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue;
		timerLose = timerLoseDefault;
		isWaiting = false;
		bool isLastBall = false;
		lockMaxBalls = false;
		lastMaxBalls = maxBalls;
		newHiScore = false;

	
		//print(PlayerPrefs.GetInt("SaveBest", 0).ToString());
		if (PlayerPrefs.HasKey("SaveBest"))
			{
			GameObject.FindWithTag("HighScore").GetComponent<Text>().text = PlayerPrefs.GetInt("SaveBest", 0).ToString();
			print("SaveBest set to previous Score");

			}
		else 
			{
			PlayerPrefs.SetInt("SaveBest", 0);
			PlayerPrefs.Save();
			print("SaveBest set to 0");
			}
	}

	void Update()
	{

		GameObject.FindWithTag("Health").GetComponent<Slider>().value = ballCount;
		GameObject.FindWithTag("HealthText").GetComponent<Text>().text = ballCount.ToString();
		GameObject.FindWithTag("Score").GetComponent<Text>().text = fusions.ToString();
		GameObject.FindWithTag("Timer").GetComponent<Text>().text = timerLose.ToString("0.0");
		GameObject.FindWithTag("MaxBallsTxt").GetComponent<Text>().text = maxBalls.ToString();






//		MaxBalls Changer

//    deve mudar  de acordo :laranja 5, terra 11
		if(GameObject.FindGameObjectsWithTag("9").Length >= 1 )
		{
			maxBalls=12+difficultyAdd;
			GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue = maxBalls;
			lockMaxBalls = true;
		}
		else
		{

			if (lockMaxBalls == false) 
			{

				//fireworks
				;
				if (maxBalls != lastMaxBalls)
				{
					lastMaxBalls = maxBalls;
					maxBallsFireworks.SetActive(false);
					maxBallsFireworks.SetActive(true);
				//	gameObject.GetComponent<Ads>().SimpleAdShow();

				}

				if(GameObject.FindGameObjectsWithTag("8").Length >= 1)
				{
					maxBalls=11+difficultyAdd;
					GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue = maxBalls;
				}	
				else
				{
					if(GameObject.FindGameObjectsWithTag("7").Length >= 1 )
					{
						maxBalls=10+difficultyAdd;
						GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue = maxBalls;
					}	
					else
					{
						if(GameObject.FindGameObjectsWithTag("6").Length >= 1 )
						{
							maxBalls=9+difficultyAdd;
							GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue = maxBalls;
						}	
						else
						{
							if(GameObject.FindGameObjectsWithTag("5").Length >= 1 )
							{
								maxBalls=8+difficultyAdd;
								GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue = maxBalls;
							}	
							else
							{
								if(GameObject.FindGameObjectsWithTag("4").Length >= 1 )
								{
									maxBalls=7+difficultyAdd;
									GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue = maxBalls;
								}	
								else
								{
									if(GameObject.FindGameObjectsWithTag("3").Length >= 1 )
									{
										maxBalls=6+difficultyAdd;
										GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue = maxBalls;
									}	
									else
									{
										if(GameObject.FindGameObjectsWithTag("2").Length >= 1 )
										{
											maxBalls=5+difficultyAdd;
											GameObject.FindWithTag("Health").GetComponent<Slider>().maxValue = maxBalls;
										}	

									}
								}
							}
						}
					}
				}
			}
		}







		if ((ballCount >= maxBalls)&&(isWaiting == false))
	//	if (ballCount >= maxBalls)
		{ 
	//		print("Dark Red");
			fillBar.GetComponent<Image>().color = new Color32(70, 0, 0, 255);

			isLastBall = true;
		}

		if(ballCount < maxBalls -4){fillBar.GetComponent<Image>().color = Color.cyan;}
		if(ballCount >= maxBalls -4 & ballCount < maxBalls -2){fillBar.GetComponent<Image>().color = new Vector4(1,0.5f,0,255);}
		if(ballCount >= maxBalls -2 & ballCount < maxBalls ){fillBar.GetComponent<Image>().color = Color.red;
	//		print("red");
		}


		//Salvar HighScore
		if (fusions > PlayerPrefs.GetInt("SaveBest", 0))
		{
			PlayerPrefs.SetInt("SaveBest", fusions);
			PlayerPrefs.Save();
			newHiScore = true;

		}

		GameObject.FindWithTag("HighScore").GetComponent<Text>().text = PlayerPrefs.GetInt("SaveBest", 0).ToString();
	}



	void YouLose()
	{
		GameObject[] LooseText;


		GameObject.FindWithTag("Timer").GetComponent<Text>().enabled = false;
		loseScreen.SetActive(true);


		if(newHiScore)
		{
			NewHiScoreScreen.SetActive(true);

			GameObject.FindWithTag("EndGameTxt").GetComponent<Text>().color = Color.yellow;
			//	GameObject.FindWithTag("EndGameTxt").GetComponentInChildren<Text>().color = new Color (0.9f,0.82f,0.0f,1f); // procura no próprio objeto também;
		}



		LooseText = GameObject.FindGameObjectsWithTag("EndGameTxt");

		foreach (GameObject text in LooseText)
		{
			text.GetComponent<Text>().text = fusions.ToString(); 
		}
	}


	//Informar o Hiscore
	public void SubmitHiScore()

	{
		
		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
		if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
		if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");
		GameObject.FindWithTag("NewHiScoreButton").GetComponent<Button>().interactable = false;
		GameObject.FindWithTag("NewHiScoreButton").GetComponentInChildren<Text>().text = "Done!";
		GameObject.FindWithTag("HiScoreTxtBox").GetComponent<InputField>().interactable = false;


		dl.AddScore(this.playerName, fusions, GameObject.FindWithTag("GameController").GetComponent<Counter>().difficultyAdd);

	}



	public void ActivateSubmitHiScoreBtn()
	{
		GameObject.FindWithTag("NewHiScoreButton").GetComponent<Button>().interactable = true;
		playerName = GameObject.FindWithTag("PlayerNameInput").GetComponent<Text>().text;
	}


	//Reseta o HighScore
	public void ResetHighScore()
	{
		PlayerPrefs.DeleteKey("SaveBest");
		print("ResetHiScr");

	}




	public IEnumerator WaitToLose()
	{
		GameObject.FindWithTag("Timer").GetComponent<Text>().enabled = true;
		isWaiting = true;
		float waitTime = 0.1f;
		yield return new WaitForSeconds(waitTime);
		timerLose = timerLose-waitTime;
		fillBar.GetComponent<Image>().color = Color.grey;

		GameObject activeBall = GameObject.FindGameObjectWithTag("Active");

		print(activeBall + " <- active ball =========== Ball Diff ->" + (maxBalls - ballCount));

		if ((activeBall == null) && (ballCount < maxBalls))
		{
			isLastBall = false;
			timerLose = timerLoseDefault;
			isWaiting = false;
			StartCoroutine (gameObject.GetComponent<LaunchBall>().Spawn());
			GameObject.FindWithTag("Timer").GetComponent<Text>().enabled = false;
		}

		if ((timerLose <= 0)&&(isWaiting == true) )
		{
			YouLose();
			isWaiting = false;
		} 


		if (isWaiting == true) {StartCoroutine (WaitToLose());};


	}


}
