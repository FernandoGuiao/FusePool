using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLeaderBoard : MonoBehaviour {
	
	dreamloLeaderBoard dl;
	dreamloPromoCode pc;


	void Start () {
		GUILayoutOption[] width200 = new GUILayoutOption[] {GUILayout.Width(200)};


		float width = 800;  // Make this wider to add more columns
		float height = 400;

		Rect r = new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2) - (height), width, height);
		GUILayout.BeginArea(r, new GUIStyle("box"));

		GUILayout.BeginVertical();



		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();	
		this.pc = dreamloPromoCode.GetSceneDreamloPromoCode();


		List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();

		int maxToDisplay = 20;
		int count = 0;
		foreach (dreamloLeaderBoard.Score currentScore in scoreList)


		{
			count++;
			GUILayout.BeginHorizontal();
			GUILayout.Label(currentScore.playerName, width200);
			GUILayout.Label(currentScore.score.ToString(), width200);
			GUILayout.EndHorizontal();

			if (count >= maxToDisplay) break;
		}

		GUILayout.EndArea();
		GUILayout.EndVertical();
	}

}
