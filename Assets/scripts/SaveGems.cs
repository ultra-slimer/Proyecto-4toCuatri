using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveGems : MonoBehaviour
{
    public int Gems;

    private void Start()
    {
        GameManager.Subscribe("UpdateSaveValues", UpdateCurrentValues);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
        }
    }

    private void UpdateCurrentValues()
    {
        Gems = SaveTesting._Gems;
    }
}
