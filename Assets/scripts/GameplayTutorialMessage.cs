using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTutorialMessage : MonoBehaviour
{
    public int ID;
    public List<string> textStrings = new List<string>();
    static List<Text> texts = new List<Text>();
    static List<Image> images = new List<Image>();
    public delegate void turn();
    public CanvasGroup canvas;
    private static CanvasGroup _canvas;

    private void Start()
    {
        texts.AddRange(canvas.GetComponents<Text>());
        images.AddRange(canvas.GetComponents<Image>());
        _canvas = canvas;
    }

    public turn ON = delegate {
        _canvas.alpha = 1;
        _canvas.blocksRaycasts = true;
        _canvas.interactable = true;
    };
    public turn OFF = delegate {
        _canvas.alpha = 0;
        _canvas.blocksRaycasts = false;
        _canvas.interactable = false;
    };
}
