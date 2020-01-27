using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineANG : MonoBehaviour {
	public Slider slider;
	private GameObject line;
	public float delay = 10f; //+ = menos smooth // - = masi smooth

	// Use this for initialization
	void Start () {
		line = gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		//constante do script principal
		float shootPWR_k = GameObject.Find("_SCRIPTS_").GetComponent<LaunchBall>().shootPWR;


	




		float sliderValue = slider.value;  // y


		float shootPWR = shootPWR_k - Mathf.Abs(sliderValue); // x
		//print (shootPWR);

	//	if (GameObject.Find("_SCRIPTS_").GetComponent<LaunchBall>().shootinPwrCorrector == -1) {  sliderValue = sliderValue*-1;}

		//alfa = y/x:
		float alpha =  sliderValue  / shootPWR ;
		//achar alfa em radiano
		float targetRad = Mathf.Atan(alpha);
		//transforma em graus
		float targetY = 180*targetRad/Mathf.PI;

//		print(targetY); // linha para verificar a resposta no console

		//converter de quartenion para Euler
		if (GameObject.Find("_SCRIPTS_").GetComponent<LaunchBall>().shootinPwrCorrector == -1) { targetY = targetY-180;}
				
		Quaternion target = Quaternion.Euler(0,targetY ,0);

		//mudar a agulação em tempo real
		line.transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * delay);

	}
}
