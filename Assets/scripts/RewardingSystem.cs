using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardingSystem : MonoBehaviour
{
    public int reward;
    public Text banner;
    private string _template;
    public ErrorMessage pressResponseMessage;
    [SerializeField]
    public List<Button> buttonsToEnable;
    public List<GameObject> buttonsToDisable;
    private void Start()
    {
        if (GameSave._bonusReward)
        {
            reward *= 2;
            GameSave._bonusReward = false;
            GameManager.Trigger("SaveRemotely");
        }
        _template = banner.text;
        banner.text += reward;
        GetComponent<AudioSource>().Play();
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
    public void MultiplyReward(int factor)
    {
        reward *= factor;
        UpdateRewardText();
    }
    public void UpdateRewardText()
    {
        banner.text = _template + reward;
    }

    public void BTN_ReceiveReward()
    {
        for (int i = 0; i < buttonsToEnable.Count; i++)
        {
            buttonsToEnable[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < buttonsToDisable.Count; i++)
        {
            buttonsToDisable[i].gameObject.SetActive(false);
        }
        CreditReward();
    }
}
