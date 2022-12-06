using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup canvas;
    public AudioSource BGM;

    private void Awake()
    {
        canvas = FindObjectOfType<CanvasGroup>();
        canvas.alpha = 0;
        AudioManager.SwitchNoise(GameSave._volume);
        //Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.ExclusiveFullScreen, 30);
    }
    private void Start()
    {
        DontDestroyOnLoad(BGM.gameObject);
    }
}
