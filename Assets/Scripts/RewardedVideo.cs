using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class RewardedVideo : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "1486551";
#elif UNITY_ANDROID
    private string gameId = "3535433";//3535433 real // 1486550 teste
#endif

    Button myButton;

   public GameObject AdsScreen;
   public GameObject LooseScreen;
    bool adInProgress;

    public string myPlacementId = "rewardedVideo";

    void Start()
    {
        adInProgress = false;
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
      
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, true);
      
        
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
      
            Advertisement.Show(myPlacementId);
        
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:

        print("AD Finished Stared");
        if (showResult == ShowResult.Finished)

        {

            
            // Reward the user for watching the ad to completion.
            if (!adInProgress)
            {
                adInProgress = true;
                GameObject.FindWithTag("GameController").GetComponent<Counter>().maxBalls = GameObject.FindWithTag("GameController").GetComponent<Counter>().maxBalls + 1;

                GameObject.FindWithTag("GameController").GetComponent<Counter>().rewardAdd = 1;
                GameObject.FindWithTag("GameController").GetComponent<Counter>().isLastBall = false;
                GameObject.FindWithTag("GameController").GetComponent<Counter>().hadReward = true;
                GameObject.FindWithTag("GameController").GetComponent<LaunchBall>().CallSpawn();
                GameObject.FindWithTag("GameController").GetComponent<Counter>().CallWaitToLoseReward();
                GameObject.FindWithTag("Timer").GetComponent<Text>().enabled = false;
                GameObject.FindWithTag("GameController").GetComponent<MenuControl>().ToggleAskAdScreen();
                print("AD Finished");
            }

        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            if (!adInProgress)
            {
                adInProgress = true;
                GameObject.FindWithTag("GameController").GetComponent<Counter>().YouLose();
                GameObject.FindWithTag("GameController").GetComponent<MenuControl>().ToggleAskAdScreen();
                print("AD Skipped");
            }


        }
        else if (showResult == ShowResult.Failed && adInProgress == false)
        {
            if (!adInProgress)
            {
                adInProgress = true;
                GameObject.FindWithTag("GameController").GetComponent<Counter>().YouLose();
                GameObject.FindWithTag("GameController").GetComponent<MenuControl>().ToggleAskAdScreen();
                print("AD Failed");

            }

        }
    }

    public void OnUnityAdsDidError(string message)
    {
        GameObject.FindWithTag("GameController").GetComponent<Counter>().YouLose();
        GameObject.FindWithTag("GameController").GetComponent<MenuControl>().ToggleAskAdScreen();
        print("AD Error");

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }
}
