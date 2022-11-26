using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardingSystem : MonoBehaviour
{
    public int reward;
    public Text banner;
    private void Start()
    {
        banner.text += reward;
    }
    public void GetRewardValue(int a)
    {
        reward = a;
    }

    public void CreditReward()
    {
        GemManager.AddGems(reward);
        GameManager.Trigger("SaveRemotely");
    }
}
