using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RewardedVideo : MonoBehaviour
{
    public string myPlacementId = "rewardedVideo";

    public void GiveLife()
    {
        GameObject.FindWithTag("GameController").GetComponent<Counter>().maxBalls = GameObject.FindWithTag("GameController").GetComponent<Counter>().maxBalls + 1;

        GameObject.FindWithTag("GameController").GetComponent<Counter>().rewardAdd = 1;
        GameObject.FindWithTag("GameController").GetComponent<Counter>().isLastBall = false;
        GameObject.FindWithTag("GameController").GetComponent<Counter>().hadReward = true;
        GameObject.FindWithTag("GameController").GetComponent<LaunchBall>().CallSpawn();
        GameObject.FindWithTag("GameController").GetComponent<Counter>().SetDepartureTime();
        GameObject.FindWithTag("GameController").GetComponent<Counter>().CallWaitToLoseReward();
        GameObject.FindWithTag("Timer").GetComponent<Text>().enabled = false;
        GameObject.FindWithTag("GameController").GetComponent<MenuControl>().DeactivateAskAdScreen();
    }
}
