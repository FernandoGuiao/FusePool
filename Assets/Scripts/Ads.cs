using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
using GoogleMobileAds.Api;


public class Ads : MonoBehaviour {


	public BannerView bannerview;
	public InterstitialAd simpleview;
	public string appID = "ca-app-pub-0054819707438435~7139129044";
//	public string banner = "ca-app-pub-0054819707438435/3092072828"; //ID REAL
//	public string simpleAd = "ca-app-pub-0054819707438435/9397572826";// ID REAL

	public string banner = "ca-app-pub-3940256099942544/6300978111"; // TEST ID
	public string simpleAd = "ca-app-pub-3940256099942544/1033173712"; // TEST ID



	public void Awake () {
		MobileAds.Initialize(appID);
	}

	public void Start () {
		print("Ads Asking to wait");
		StartCoroutine(WaitADLoad());
		print("Ads Asked to wait done");
	}

	public void BannerAd () {
		print("Ads Banner Ad Load Start");
		bannerview = new BannerView (banner, AdSize.Banner, AdPosition.Top);
		AdRequest request = new AdRequest.Builder().Build();
		bannerview.LoadAd(request);
		bannerview.Show();
		print("Ads Banner Ad Loaded");
		StartCoroutine(ChangeBanner());
	}
	

	public void SimpleAd () {
		simpleview = new InterstitialAd(simpleAd);
		AdRequest request = new AdRequest.Builder().Build();
		simpleview.LoadAd(request);
		print("Ads Simple Ad askd to Load");
	
	}


	public void SimpleAdShow () {


		if (simpleview.IsLoaded()) 
		{
			print("Ads Simple Ad is Loaded");
			bannerview.Destroy();
			simpleview.Show();
			print("Ads Simple Ad Shown");
  		}
		else{print("Ads Simple Ad !NOT! Loaded");}


	}



	public IEnumerator WaitADLoad()
	{
		print("Ads Inicial Waiting");
		yield return new WaitForSecondsRealtime(5);
		BannerAd();
		SimpleAd();
		print("Ads Inicial Started");
	}

	public IEnumerator ChangeBanner()
	{
		print("Ads Waiting 20sec to BannerChange");
		yield return new WaitForSecondsRealtime(20);
		bannerview.Destroy();
		BannerAd();
		print("Ads asked to BannerChange");
	}

}



*/