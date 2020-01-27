using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawners : MonoBehaviour {

	public GameObject[] ballSpawners;
	public int activeBallSpawnInt = 0 ; 
	GameObject camCenter;
	Quaternion target;
	public Animator anim;

	// Use this for initialization
	void Start () {
		camCenter = GameObject.Find("CenterMark");
		target = Quaternion.Euler(0, camCenter.GetComponent<Transform>().rotation.y, 0);


		ballSpawners = GameObject.FindGameObjectsWithTag("BallSpawner");

		activeBallSpawnInt = 0;

	//	print(ballSpawners.Length+1); //

		for ( int i = 0;  i < ballSpawners.Length; i++)
		{

			ballSpawners[i].tag ="Untagged";
		//	print(ballSpawners[i] + "  untaggaed");
	
		}

		ballSpawners[0].tag = "BallSpawner";
	//	print(ballSpawners[0] + "  taggaed");
	}



	public void ChangeSpawn()
	{

		GameObject activeBallSpawn = GameObject.FindGameObjectWithTag("BallSpawner");

		activeBallSpawn.tag = "Untagged";

		if (activeBallSpawnInt == 0) {
			activeBallSpawnInt = 1; 
			anim.SetInteger("spawncam",1);
			ballSpawners[activeBallSpawnInt].tag = "BallSpawner";}

		else { 
			activeBallSpawnInt --;

			ballSpawners[activeBallSpawnInt].tag = "BallSpawner"; anim.SetInteger("spawncam",2);
		}

		//apaga todas as linhas
		GameObject[] lines = GameObject.FindGameObjectsWithTag ("Line");
		for ( int i = 0;  i <= lines.Length-1; i++)
		{
			lines[i].GetComponent<LineRenderer>().enabled = false;;
		}
		//traspota bola para spawn ativo
		GameObject activeball = GameObject.FindWithTag("Active");
		activeball.GetComponent<Transform>().position = GameObject.FindWithTag("BallSpawner").GetComponent<Transform>().position;

		//ativa linha do spwn ativo
		GameObject.FindWithTag ("BallSpawner").GetComponentInChildren<LineRenderer>().enabled = true;

		GameObject.Find("_SCRIPTS_").GetComponent<LaunchBall>().ChangePWRcorrector();


	}

		/*

		target = Quaternion.Euler(0, camCenter.GetComponent<Transform>().rotation.y + 180, 0);





	





	}

	void Update()
	{
		camCenter.transform.rotation = Quaternion.Slerp(camCenter.transform.rotation, target, Time.deltaTime * 10);
		print(target);
	}

	*/


}
