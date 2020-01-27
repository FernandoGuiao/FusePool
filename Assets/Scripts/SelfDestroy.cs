using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

	public void selfDestoy () {
		DestroyObject(gameObject);
	}

	public void selfEnable () {
		gameObject.SetActive(true);
	}

}
