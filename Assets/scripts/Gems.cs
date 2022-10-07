using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Gems : Spawnables<Gems, GemSpawner>, ITouchable
{
    public int value = 5;
    public override void Update()
    {
        base.Update();
    }
    
    public void Touched(RaycastHit hit)
    {
        GemManager.AddGems(value);
        _referenceBack.ReturnObject(this);
        GameManager.Trigger("SaveRemotely");
    }

}
