using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Gems : Spawnables<Gems, GemSpawner>, ITouchable
{
    public static int _Gems;


    public override void Update()
    {
        base.Update();
    }
    public void AddGems(int amountAdded = 5)
    {
        _Gems += amountAdded;
    }
    
    public void Touched()
    {
        AddGems();
        _referenceBack.ReturnObject(this);
        GameManager.Trigger("SaveRemotely");
    }

}
