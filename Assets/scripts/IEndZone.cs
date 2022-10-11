using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEndZone
{
    public void Damage(float a);
    public void AttackAgressor(float a, IDamageable<float> b);
}
