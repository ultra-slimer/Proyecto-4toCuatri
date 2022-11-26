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
    public void Select(StoreObject storeObject) {
        if (storeObject.pressResponseMessage.GetComponent<Confirmation>())
        {
            var a = storeObject.pressResponseMessage.GetComponent<Confirmation>();
            a.Yes = delegate { if (storeObject.price < GemManager._Gems) { GemManager.AddGems(-storeObject.price); }; GameManager.Trigger("SaveRemotely"); Store.instance.ReloadGems(); ScreenManager.instance.CloseAll(); };
            a.No = delegate { ScreenManager.instance.Pop(); };
        }
        ScreenManager.instance.Push(storeObject.pressResponseMessage);
    }
    public void ReloadGems()
    {
        text.text = "Gems: " + GameSave.gems;
    }
}
