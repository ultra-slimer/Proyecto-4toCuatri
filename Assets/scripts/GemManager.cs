using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GemManager 
{
    public static int _Gems;


    public static void AddGems(int amountAdded = 5)
    {
        _Gems += amountAdded;
    }
}
