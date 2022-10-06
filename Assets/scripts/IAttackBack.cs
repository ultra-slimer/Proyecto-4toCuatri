using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackBack
{
    public void AttackAgressor(float damage, IDamageable<float> agressor);
}
