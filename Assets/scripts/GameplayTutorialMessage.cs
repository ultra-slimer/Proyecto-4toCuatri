using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTutorialMessage : MonoBehaviour
{
    public int ID;
    public List<string> textStrings = new List<string>();
    public List<Text> texts = new List<Text>();
    public List<Image> images = new List<Image>();
    public GameplayTutorialMessage nextMessage;
    public delegate void turn();
    public Canvas canvas;

    public turn ON;
    public turn OFF;
}
