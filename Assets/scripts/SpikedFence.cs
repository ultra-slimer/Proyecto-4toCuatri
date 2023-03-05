using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedFence : Cards, IAttackBack
{
    public LayerMask layerMask;

    public void AttackAgressor(float damage, IDamageable<float> agressor)
    {
        agressor.Damage(damage);
    }

    public override void Damage(float damageTaken, float multiplier = 1)
    {
        base.Damage(damageTaken);
    }
}
