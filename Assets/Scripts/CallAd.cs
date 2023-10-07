using UnityEngine;

public class CallAd : MonoBehaviour
{

#if UNITY_IOS
    private string gameId = "1486551";
#elif UNITY_ANDROID
	private string gameId = "3535433";//3535433 real // 1486550 teste
#endif

	void Start()
	{
		//
	}

	public void CallSimpleAd()
	{
		//
	}
}