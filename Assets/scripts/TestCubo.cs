using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubo : Cards
{
    public LayerMask layerMask;
    public EnemyFather enemy;
    public override void Damage(float damageTaken)
    {
        enemy.Damage(damage);
        base.Damage(damageTaken);
    }
}
