using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup canvas;

    private void Awake()
    {
        canvas = FindObjectOfType<CanvasGroup>();
        canvas.alpha = 0;
        //Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.ExclusiveFullScreen, 30);
    }
}
