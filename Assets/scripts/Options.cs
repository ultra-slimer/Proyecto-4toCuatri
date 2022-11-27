using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public ScreenMessage canvasGroup;
    public Slider slider;
    [Range(0f, 1f)]
    public float volume;

    private void Awake()
    {
        volume = GameSave._volume;
        slider.value = volume;
    }

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

    public void ChangeVolume()
    {
        volume = slider.value;
        GameSave._volume = volume;
        GameManager.Trigger("SaveRemotely");
        AudioManager.SwitchNoise(volume);
        FindObjectOfType<AudioSource>().Play();
    }
}
