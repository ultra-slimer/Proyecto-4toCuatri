using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : ScreenMessage
{
    public string errorMessageText;
    public Text text;
    public override void Activate()
    {
        text.text = errorMessageText;
        SetTransparent(1);
        SetInteractionsButtons(true);
        gameObject.SetActive(true);
    }

    public override void Desactivate()
    {
        SetTransparent(0);
        SetInteractionsButtons(false);
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Desactivate();
    }

    public void BTN_Close()
    {
        ScreenManager.instance.CloseAll();
    }
}
