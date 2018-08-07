using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
public static class AdsController
{

    private static BannerView bannerView;

    public static void ShowBanner()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-9057424491061407~3755607879";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
            string appId = "unexpected_platform";
        #endif
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        RequestBanner();
    }

    public static void ShowRewardedAd(string adsID, System.Action<ShowResult> action)
    {
        if (Advertisement.IsReady(adsID))
        {
            var options = new ShowOptions { resultCallback = action };
            Advertisement.Show(adsID, options);
        }
    }

    private static void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown."); 
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    private static void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-9057424491061407/2736796401";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
}
