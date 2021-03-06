using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class SelectForce : MonoBehaviour, IPointerDownHandler, IPointerUpHandler// required interface when using the OnPointerDown method.
{
	//Do this when the mouse is clicked over the selectable object this script is attached to.
	public void OnPointerDown (PointerEventData eventData) 
	{
		if (gameObject.GetComponent<Button>().interactable == true)
		{
		GameObject.Find("_SCRIPTS_").GetComponent<LaunchBall>().forceChange = true;
		LaunchBall lb = GameObject.Find("_SCRIPTS_").GetComponent<LaunchBall>();
		StartCoroutine (lb.ForceVar());
		print("button down");
		}
	}


	public void OnPointerUp (PointerEventData eventData) 
	{
		if (gameObject.GetComponent<Button>().interactable == true)
		{
		GameObject.Find("_SCRIPTS_").GetComponent<LaunchBall>().forceChange = false;
		print("button click");
		}
	}

}