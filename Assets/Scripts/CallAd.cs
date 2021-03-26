using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Advertisements;

public class CallAd : MonoBehaviour
{

#if UNITY_IOS
    private string gameId = "1486551";
#elif UNITY_ANDROID
	private string gameId = "3535433";//3535433 real // 1486550 teste
#endif

	void Start()
	{
		Advertisement.Initialize(gameId, true);
	}

	public void CallSimpleAd()
	{
		 print("Calling simple ad");
		if (Advertisement.IsReady("video"))
		{
			Advertisement.Show("video");
		}

	}
}