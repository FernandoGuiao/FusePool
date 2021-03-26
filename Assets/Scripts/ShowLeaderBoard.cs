using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.UI;

public class ShowLeaderBoard : MonoBehaviour {

		//	http://dreamlo.com/lb/nBgwFeElnUaz22ZDHQGZGwHGo5Z0ziz02XnnteBT9KMg

		//	nBgwFeElnUaz22ZDHQGZGwHGo5Z0ziz02XnnteBT9KMg

	//		5e2f1d2cfe2246144c6c5910


	dreamloLeaderBoard dl;
	dreamloPromoCode pc;

	public GameObject hSName;
	public GameObject hSScore;
	public GameObject hardFlag;
	public GameObject loadingIcon;


	void Start () 
	{
		print("Starting LeaderBoard");
		loadingIcon.SetActive(true);
		loadingIcon.GetComponent<Text>().text = "Connecting...";
		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();	
		dl.LoadScores();
		StartCoroutine(ShowScores());


	}


	IEnumerator ShowScores()
	{
			
		yield return new WaitForSeconds(4);

		try
		{
			List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();

			int maxToDisplay = 11;
			float count = 0f;
			print("ScoreList:  "+scoreList[0].playerName);

			if(scoreList[0].playerName != "")
			{
				loadingIcon.SetActive(false);

				foreach (dreamloLeaderBoard.Score currentScore in scoreList)
				{

					float lineSpace = hSName.GetComponent<RectTransform>().sizeDelta.y;
					float move = hSName.transform.position.y - (lineSpace*(count+1));
					float move2 = hSScore.transform.position.y - (lineSpace*(count+1));

					//Criar linhas player
					GameObject clone = Instantiate(hSName,hSName.transform.position,Quaternion.identity);

					clone.transform.SetParent(gameObject.transform);
					clone.transform.localScale = hSName.transform.localScale;
					clone.GetComponent<RectTransform>().anchoredPosition = hSName.GetComponent<RectTransform>().anchoredPosition;
					clone.transform.localRotation = hSName.transform.localRotation;
					clone.transform.localPosition = new Vector3(hSName.transform.position.x,move,hSName.transform.position.z);
					clone.GetComponent<Text>().text = currentScore.playerName;
					clone.transform.SetParent(hSName.transform.parent);


					//criar linhas score
					GameObject clone2 = Instantiate(hSScore,hSScore.transform.position,Quaternion.identity);

					clone2.transform.SetParent(gameObject.transform);
					clone2.transform.localScale = hSScore.transform.localScale;
					clone2.transform.localRotation = hSScore.transform.localRotation;
					clone2.transform.localPosition = new Vector3(hSScore.transform.position.x, move2, hSScore.transform.position.z);
					clone2.GetComponent<Text>().text = currentScore.score.ToString();
					clone2.transform.SetParent(hSScore.transform.parent);

					//criar linhas do flag


					GameObject clone3 = Instantiate(hardFlag,hardFlag.transform.position,Quaternion.identity);

						clone3.transform.SetParent(gameObject.transform);
						clone3.transform.localScale = hardFlag.transform.localScale;
						clone3.transform.localRotation = hardFlag.transform.localRotation;
						clone3.transform.localPosition = new Vector3(hardFlag.transform.position.x, move2, hardFlag.transform.position.z);
						clone3.transform.SetParent(hardFlag.transform.parent);
					if (currentScore.seconds == 0)
					{
						clone3.GetComponent<Image>().enabled = true;
					}

						count++;

					//	print(currentScore.playerName);
					//	print(currentScore.score.ToString());



						if (count >= maxToDisplay) break;
				}
			
			}
		
		}
		catch(ArgumentOutOfRangeException)
		{
			print("Connection fail catch");
			loadingIcon.GetComponent<Text>().color = Color.red;
			Start();

		}
		
	}

}
