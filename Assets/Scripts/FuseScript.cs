using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuseScript : MonoBehaviour {
	

	public GameObject explosion;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "Untagged"){
	//	gameObject.GetComponent<AudioSource>().Play(); //play sound
		}

		//se tag são iguais
		if (other.gameObject.tag == tag){
			
			if (int.Parse(tag) < GameObject.FindWithTag("GameController").GetComponent<LaunchBall>().ballPrefabs.Length -1){

				if(other.gameObject.GetComponent<Rigidbody>().velocity.magnitude < gameObject.GetComponent<Rigidbody>().velocity.magnitude){

					Instantiate(explosion, gameObject.GetComponent<Transform>().transform.position, gameObject.GetComponent<Transform>().transform.rotation );
					Destroy(other.gameObject);
					int tagInt = int.Parse(tag);

					GameObject clone = (GameObject) Instantiate(GameObject.FindWithTag("GameController").GetComponent<LaunchBall>().ballPrefabs[tagInt+1], gameObject.GetComponent<Transform>().transform.position, gameObject.GetComponent<Transform>().transform.rotation);
					clone.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;

					Destroy(gameObject);
					GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().ballCount = GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().ballCount -1;
					GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().fusions = GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().fusions +1;
					//se estiver no hard conta mais um
					if (GameObject.FindWithTag("GameController").GetComponent<Counter>().difficultyAdd == 0)
					{GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().fusions = GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().fusions +1;}

				}

			}
			else YouWin();

		}


	}

	void YouWin()
	{
		print("You Win");

		GameObject.FindWithTag("GameController").GetComponent<Counter>().endGameScreen.SetActive(true);
		Text EndGameTxt = GameObject.FindGameObjectWithTag("EndGameTxt").GetComponent<Text>();
		EndGameTxt.text = "+100! pts";
		GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().fusions = GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().fusions +50;
		GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().ballCount = GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().ballCount -1;
		GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().fusions = GameObject.FindGameObjectWithTag("GameController").GetComponent<Counter>().fusions +1;
		Destroy(gameObject);
	}


}
