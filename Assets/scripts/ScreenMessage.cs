using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ScreenMessage : MonoBehaviour, IScreen
{
    public ScreenMessage nextScreen;

    public virtual void BTN_NextScreen()
    {
        ScreenManager.instance.Push(nextScreen);
    }

    public virtual void BTN_Return()
    {
        ScreenManager.instance.Pop();
    }

    public abstract void Activate();

    public abstract void Desactivate();

    public virtual void Trasparent()
    {
        SetTransparent(0.5f);
        SetInteractionsButtons(false);
    }

    public virtual void SetInteractionsButtons(bool active)
    {
        var b = GetComponentsInChildren<Button>();

        foreach (var item in b)
        {
            item.interactable = active;
        }
    }

    public virtual void SetTransparent(float alpha)
    {
        if (GetComponent<Image>())
        {
            var c = GetComponent<Image>().color;
            c.a = alpha;
            GetComponent<Image>().color = c;
        }
        else if (GetComponent<CanvasGroup>())
        {
            var c = GetComponent<CanvasGroup>();
            c.alpha = alpha;
        }
    }
}
