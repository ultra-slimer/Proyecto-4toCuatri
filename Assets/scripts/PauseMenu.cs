using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool paused;
    public List<CanvasGroup> canvas;

    private void Start()
    {
        Time.timeScale = 1;
        canvas[1].alpha = 0;
        canvas[1].blocksRaycasts = false;
        canvas[1].interactable = false;
    }
    public void EnterPause()
    {
        canvas[1].alpha = 1;
        canvas[1].interactable = true;
        canvas[1].blocksRaycasts = true;
        canvas[0].alpha = 0;
        canvas[0].interactable = false;
        Time.timeScale = 0;
        paused = true;
        /*foreach(var a in canvas)
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
    public void LeavePause()
    {
        Time.timeScale = 1;
        canvas[1].alpha = 0;
        canvas[0].alpha = 1;
        paused = false;
        canvas[1].blocksRaycasts = false;
        canvas[1].interactable = false;
        canvas[0].interactable = true;
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
    public void MainMenu()
    {
        Time.timeScale = 1;
        paused = false;
        SceneLoader.Instance().AsyncLoadScene("MainMenu");
    }
}
