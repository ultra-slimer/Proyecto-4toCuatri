using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool paused;
    public List<Canvas> canvas;

    private void Start()
    {
        Time.timeScale = 1;
        foreach (var a in canvas)
        {
            if (a.gameObject.name == "PauseMenu")
            {
                a.enabled = false;
            }
        }
    }
    public void EnterPause()
    {
        foreach(var a in canvas)
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
        }
    }
    public void LeavePause()
    {
        foreach (var a in canvas)
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
        }
    }
}
