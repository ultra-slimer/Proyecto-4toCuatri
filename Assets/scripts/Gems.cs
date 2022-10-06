using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Gems : Spawnables<Gems, GemSpawner>
{
    public static int _Gems;


    ObjectPool<Gems> _referenceBack;
    private void Start()
    {
        thing = this;
    }
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            SaveOnlyGems();
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            AddGems(5);
        }
        base.Update();
    }
    public void AddGems(int amountAdded)
    {
        _Gems += amountAdded;
        GameManager.Trigger("UpdateSaveWithModifiedValues");
    }
    
    public void SaveOnlyGems()
    {
        GameManager.Trigger("SaveRemotely");
    }
}
