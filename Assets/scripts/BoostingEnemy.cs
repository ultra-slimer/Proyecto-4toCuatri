using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostingEnemy : EnemyFather, ISpawnable<BoostingEnemy>
{
    public BoxCollider boosteeDetector;
    public EnemyFather boostee;
    public void SaveThing(BoostingEnemy newThing)
    {
        self = newThing;
    }

    public override void EnemyAction()
    {
    }

    private void Start()
    {
    }
}
