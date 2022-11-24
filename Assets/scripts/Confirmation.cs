using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirmation : ScreenMessage
{
    public delegate void confirm();
    public confirm Yes;
    public confirm No;
    public override void Activate()
    {
        gameObject.SetActive(true);
        SetTransparent(1);
        SetInteractionsButtons(true);
    }

    public override void Desactivate()
    {
        gameObject.SetActive(false);
    }

    public void BTN_Yes()
    {
        Yes();
    }

    public void BTN_No()
    {
        No();
    }
}
