using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulse : MonoBehaviour {

	float repulsePWR;

	void Start()
	{
		repulsePWR = GameObject.FindWithTag("GameController").GetComponent<RepulsePWR>().repulsePower;

	}


	void OnTriggerStay(Collider other)
	{



		if (other.tag != "Active"){




			if (other.attachedRigidbody){

				GameObject spawnerPosGO = gameObject;
				Transform spawnerPos = spawnerPosGO.GetComponent<Transform>();

				Vector3 heading = new Vector3(0,0,-49) - spawnerPos.position;
				//print(gameObject + "  " + heading);
				other.attachedRigidbody.AddForce(heading * repulsePWR );
			}

		}
	}


}
