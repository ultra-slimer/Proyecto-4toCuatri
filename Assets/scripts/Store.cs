using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Text text;
    public static Store instance;
    private StoreObject[] storeObjects;
    [SerializeField] public ErrorMessage errorMessages;
    private void Awake()
    {
        instance = this;
        ReloadGems();
    }
    private void Start()
    {
        instance = this;
        ReloadGems();
    }
    /*public void Select(StoreObject storeObject, int purchaseID) {
        if (storeObject.pressResponseMessage.GetComponent<Confirmation>())
        {
            var a = storeObject.pressResponseMessage.GetComponent<Confirmation>();
            a.Yes = delegate { if (storeObject.price < GemManager._Gems) { GemManager.AddGems(-storeObject.price); AudioManager.Instance().Play("Positive"); Buy(purchaseID); } else { ScreenManager.instance.Push(errorMessage); AudioManager.Instance().Play("Negative"); } GameManager.Trigger("SaveRemotely"); Store.instance.ReloadGems(); ScreenManager.instance.CloseAll(); };
            a.No = delegate { AudioManager.Instance().Play("Neutral"); ScreenManager.instance.Pop(); };
        }
        ScreenManager.instance.Push(storeObject.pressResponseMessage);
    }*/
    public void ReloadGems()
    {
        text.text = "Gems: " + GameSave.gems;
    }

    public static void Buy(int a, StoreObject bought)
    {
        switch (a)
        {
            default:
                print("Bought Nothing");
                break;
            case 1:
                //StaminaSystem.instance.RestoreEnergy();
                print("a");
                FindObjectOfType<StaminaSystem>().FullRecharge();
                AudioManager.Instance().Play("Positive");
                GemManager.AddGems(-bought.price); 
                ScreenManager.instance.CloseAll();
                break;
            case 2:
                GameManager.Trigger("UpdateWithSaveValues");
                if (GameSave._bonusReward)
                {
                    instance.errorMessages.errorMessageText = "You already have this enabled"; 
                    ScreenManager.instance.Push(instance.errorMessages);
                    AudioManager.Instance().Play("Negative");

                }
                else
                {
                    GameSave._bonusReward = true;
                    AudioManager.Instance().Play("Positive");
                    GemManager.AddGems(-bought.price); 
                    ScreenManager.instance.CloseAll();
                }
                break;
            case 3:
                GameManager.Trigger("UpdateWithSaveValues");
                if (GameSave._increasedGemChance)
                {
                    instance.errorMessages.errorMessageText = "You already have this enabled";
                    ScreenManager.instance.Push(instance.errorMessages);
                    AudioManager.Instance().Play("Negative");
                }
                else
                {
                    GameSave._increasedGemChance = true;
                    AudioManager.Instance().Play("Positive");
                    GemManager.AddGems(-bought.price);
                    ScreenManager.instance.CloseAll();
                }
                break;
        }
    }
}
