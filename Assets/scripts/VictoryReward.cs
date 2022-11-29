using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class VictoryReward : AdManager
{
    public RewardingSystem rewardingSystem;
    private bool _done = false;
    public Button button;
    public int multiplicationFactor;

    public override void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android")
        {
            if (ShowResult.Finished == showResult)
            {
                Debug.Log("Te doy la recompensa");
                rewardingSystem.MultiplyReward(multiplicationFactor);
                _done = false;
                button.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Dudo, no te doy nada");
            }
        }
    }
    public void BTN_MultiplyRewards()
    {
        PlayAd();
    }
}
