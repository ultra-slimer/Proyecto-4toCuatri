using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : ScreenMessage, IScreen
{
    public static bool paused;
    public int pauseID;
    public List<CanvasGroup> canvas;
    private void Start()
    {
        Time.timeScale = 1;
        //canvas[pauseID].alpha = 0;
        //canvas[pauseID].blocksRaycasts = false;
        SetTransparent(1);
        SetInteractionsButtons(false);
        canvas[pauseID].gameObject.SetActive(false);
    }
    public override void Activate()
    {
        for (int i = 0; i < canvas.Count; i++) {
            if(i == pauseID)
            {
                Time.timeScale = 0;
                paused = true;
                //canvas[i].alpha = 1;
                //canvas[i].blocksRaycasts = true;
                SetTransparent(1);
                SetInteractionsButtons(true);
                canvas[i].gameObject.SetActive(true);
            }
            else
            {
                //canvas[i].alpha = 0;
                //canvas[i].interactable = false;
                canvas[i].gameObject.SetActive(false);
            }
        }
        /*foreach (var a in canvas)
        {
            if (a.gameObject.name != "PauseMenu")
            {
                a.enabled = false;
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                a.enabled = true;
            }
        }*/
    }

    public override void Desactivate()
    {

        for (int i = 0; i < canvas.Count; i++)
        {
            if (i != pauseID)
            {
                /*canvas[i].alpha = 1;
                canvas[i].interactable = true;*/
                SetInteractionsButtons(true);
                canvas[i].gameObject.SetActive(true);
            }
            else
            {
                print("a");
                Time.timeScale = 1;
                paused = false;/*
                canvas[i].alpha = 0;
                canvas[i].blocksRaycasts = false;
                SetInteractionsButtons(false);*/
                canvas[i].gameObject.SetActive(false);
            }
        }
        /*foreach (var a in canvas)
        {
            if (a.gameObject.name != "PauseMenu")
            {
                a.enabled = true;
            }
            else
            {
                a.enabled = false;
                paused = false;
                Time.timeScale = 1;
            }
        }*/
    }

    public void BTN_Resume()
    {
        ScreenManager.instance.Pop();
        //Desactivate();
    }

    public void BTN_Pause()
    {
        ScreenManager.instance.Push(this);
    }

    public void BTN_MainMenu()
    {
        if (nextScreen.GetComponent<Confirmation>())
        {
            var a = nextScreen.GetComponent<Confirmation>();
            a.Yes = delegate { PauseMenu.MainMenu(); };
            //a.No = delegate { ScreenManager.instance.Pop(); };
            a.No = delegate { ScreenManager.instance.CloseAll(); };
        }
        ScreenManager.instance.Push(nextScreen);
    }
    public static void MainMenu()
    {
        Time.timeScale = 1;
        paused = false;
        SceneLoader.Instance().AsyncLoadScene("MainMenu");
    }
}
