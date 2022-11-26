using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public ScreenMessage canvasGroup;

    public void DeleteConfirmation()
    {

        if (canvasGroup.GetComponent<Confirmation>())
        {
            var a = canvasGroup.GetComponent<Confirmation>();
            a.Yes = delegate { GetComponent<EventSystem>().DeleteSave(); ScreenManager.instance.CloseAll(); };
            a.No = delegate { ScreenManager.instance.Pop(); };
        }
        ScreenManager.instance.Push(canvasGroup);
        /*canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;*/
    }
    public void CloseConfirmation()
    {
        /*canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;*/
    }
}
