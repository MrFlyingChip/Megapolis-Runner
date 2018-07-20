using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public static class AdsController
{

    public static void ShowRewardedAd(string adsID)
    {
        if (Advertisement.IsReady(adsID))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
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
}
