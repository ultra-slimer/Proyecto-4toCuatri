using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class StoreObject : MonoBehaviour
{
    public int purchaseID;
    public ScreenMessage pressResponseMessage;
    public int price;
    public string objectName;
    private string _title; // title should be = to "name priceG"

   



    //public static StoreObject Instance;
    private void Start()
    {
        /*
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        */

        _title = $@"{objectName} - {price}G";
        GetComponentInChildren<Text>().text = _title;
    }

    public void Press()
    {
        //StaminaSystem.instance.FullRecharge();

        
        if (pressResponseMessage.GetComponent<Confirmation>())
        {
            var a = pressResponseMessage.GetComponent<Confirmation>();
            a.Yes = delegate { if (price <= GemManager._Gems) { GemManager.AddGems(-price); Store.Buy(purchaseID); ScreenManager.instance.CloseAll(); } else { pressResponseMessage.nextScreen.GetComponent<ErrorMessage>().errorMessageText = "Insufficient Gems"; ScreenManager.instance.Push(pressResponseMessage.nextScreen); AudioManager.Instance().Play("Negative"); } GameManager.Trigger("SaveRemotely"); Store.instance.ReloadGems();};
            a.No = delegate { AudioManager.Instance().Play("Neutral"); ScreenManager.instance.Pop(); };
        }
        AudioManager.Instance().Play("Neutral");
        ScreenManager.instance.Push(pressResponseMessage);
        //Store.instance.Select(this, purchaseID);
        
    }
}
