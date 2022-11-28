using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Text text;
    public static Store instance;
    private StoreObject[] storeObjects;
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
    public void Select(StoreObject storeObject, int purchaseID) {
        if (storeObject.pressResponseMessage.GetComponent<Confirmation>())
        {
            var a = storeObject.pressResponseMessage.GetComponent<Confirmation>();
            a.Yes = delegate { if (storeObject.price < GemManager._Gems) { GemManager.AddGems(-storeObject.price); AudioManager.Instance().Play("Positive"); Buy(purchaseID); }; GameManager.Trigger("SaveRemotely"); Store.instance.ReloadGems(); ScreenManager.instance.CloseAll(); };
            a.No = delegate { AudioManager.Instance().Play("Neutral"); ScreenManager.instance.Pop(); };
        }
        ScreenManager.instance.Push(storeObject.pressResponseMessage);
    }
    public void ReloadGems()
    {
        text.text = "Gems: " + GameSave.gems;
    }

    private void Buy(int a)
    {
        switch (a)
        {
            default:
                print("Bought Nothing");
                break;
            case 1:
                //StaminaSystem.instance.RestoreEnergy();
                break;
        }
    }
}
