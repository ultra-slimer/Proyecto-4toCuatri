using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Gems : Spawnables<Gems, GemSpawner>
{
    public static int _Gems;


    public override void Update()
    {
        base.Update();
    }
    public static void AddGems(int amountAdded = 5)
    {
        _Gems += amountAdded;
        Gems.SaveOnlyGems();
    }
    
    public static void SaveOnlyGems()
    {
        GameManager.Trigger("SaveRemotely");
    }

}
