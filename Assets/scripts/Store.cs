using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Text text;
    private void Awake()
    {
        text.text = "Gems: " + GameSave.gems;
    }
}
