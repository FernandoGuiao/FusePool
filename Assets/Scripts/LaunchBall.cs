using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class LaunchBall : MonoBehaviour {
	GameObject activeBall;
	GameObject ballSpawner;
	public int shootinPwrCorrector = 1;
	public bool forceChange;

	public GameObject launchButton;


	public Slider slider;
	public int shootPWR = 50;
	public float shootPWRmod = 0;

	public GameObject[] ballPrefabs;

	public GameObject spawnFX;

	void Start() {
		slider.maxValue = shootPWR;
		slider.minValue = -shootPWR;
		activeBall = GameObject.FindGameObjectWithTag("Active");
		ballSpawner = GameObject.FindGameObjectWithTag("BallSpawner");
	}




	public void Shoot() {


		DestroyExplosion();
		print("Shoot!");
		activeBall = GameObject.FindGameObjectWithTag("Active");
	//	activeBall.AddForce(0,0,shootPWR);
		float shootANG = slider.value;
		if (shootinPwrCorrector ==-1){shootANG = shootANG*-1;}
		float shootPWRtemp = shootPWR- Mathf.Abs(shootANG);
		activeBall.GetComponent<Rigidbody>().isKinematic = false;
		Vector3 velocityVector = new Vector3 (shootANG,0,shootPWRtemp*shootinPwrCorrector);
		activeBall.GetComponent<Rigidbody>().velocity = velocityVector*(shootPWRmod);
		activeBall.tag = "0";

		GameObject[] lines = GameObject.FindGameObjectsWithTag ("Line");


		for ( int i = 0;  i <= lines.Length-1; i++)
		{

			lines[i].GetComponent<LineRenderer>().enabled = false;;

		}
		launchButton.GetComponent<Button>().interactable = false;
			
		if (gameObject.GetComponent<Counter>().isLastBall == false)
		{
		StartCoroutine(Spawn());
		}
		else{StartCoroutine (gameObject.GetComponent<Counter>().WaitToLose());}
	}
		







	public void ChangePWRcorrector()
	{
		ballSpawner = GameObject.FindGameObjectWithTag("BallSpawner");
		if (ballSpawner.GetComponent<Transform>().position.z < -49) {shootinPwrCorrector = 1;}
		else {shootinPwrCorrector = -1;}
	}








		public IEnumerator Spawn()
		{

		if (gameObject.GetComponent<Counter>().ballCount < gameObject.GetComponent<Counter>().maxBalls){

			float waitTime = 1f;

			yield return new WaitForSeconds(waitTime);
			ballSpawner = GameObject.FindGameObjectWithTag("BallSpawner");
			Instantiate(ballPrefabs[0], ballSpawner.GetComponent<Transform>().position, ballSpawner.GetComponent<Transform>().rotation);
		

			//StartCoroutine(SpawnGrow());

			activeBall = GameObject.FindGameObjectWithTag("Spawning");
			activeBall.GetComponent<Rigidbody>().isKinematic = true;
			activeBall.GetComponent<Transform>().localScale = new Vector3 (0,0,0);

			for ( float i = 0;  i <= 2.1f; i=i+0.1f)
			{
				activeBall.GetComponent<Transform>().localScale = new Vector3 (i,i,i);
				yield return new WaitForSeconds(0.01f);
			}

			//yield return new WaitForSeconds(waitTime/2);
			activeBall.tag = "Active";
			activeBall = GameObject.FindGameObjectWithTag("Active");

			gameObject.GetComponent<Counter>().ballCount = gameObject.GetComponent<Counter>().ballCount +1;

			GameObject.FindWithTag ("BallSpawner").GetComponentInChildren<LineRenderer>().enabled = true;
			launchButton.GetComponent<Button>().interactable = true;;
			print(ballSpawner);

			if (ballSpawner.GetComponent<Transform>().position.z < -49) {shootinPwrCorrector = 1;}
			else {shootinPwrCorrector = -1;}

			ChangePWRcorrector();

			}
		}

	public void DestroyExplosion()
	{
		GameObject[] explosion = GameObject.FindGameObjectsWithTag("Explosion");
		int i;
		for(i=0;i<explosion.Length;i++)
		{Destroy(explosion[i]);}

	

	}




	public IEnumerator ForceVar()
	{
		print("startForceVar");

		if (forceChange == true) 
		{

			if (shootPWRmod <=2)
			{
				shootPWRmod = shootPWRmod+0.1f;
				GameObject.FindGameObjectWithTag("ForceSlider").GetComponent<Slider>().value = shootPWRmod;
				float waitTime = 0.1f;
				yield return new WaitForSeconds(waitTime);
				StartCoroutine(ForceVar());
				print("+POWER");
			}
			else
			{
				forceChange = false;
				StartCoroutine(ForceVar());
			}
		}
		else
		{
			print("Shooooottt!!!!!!");
			Shoot();
			shootPWRmod = 0.6f;
			GameObject.FindGameObjectWithTag("ForceSlider").GetComponent<Slider>().value = shootPWRmod;
		}




	}

	public IEnumerator SpawnGrow()
	{
		activeBall = GameObject.FindGameObjectWithTag("Active");
		activeBall.GetComponent<Transform>().localScale = new Vector3 (0,0,0);

		for ( float i = 0;  i <= 2.1f; i=i+0.1f)
		{
			activeBall.GetComponent<Transform>().localScale = new Vector3 (i,i,i);
			yield return new WaitForSeconds(0.01f);
		}
	}

}
