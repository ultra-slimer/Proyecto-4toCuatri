using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : EnemyFather, ISpawnable<SmartEnemy>
{
    public void SaveThing(SmartEnemy newThing)
    {
        thing = newThing;
    }
}
