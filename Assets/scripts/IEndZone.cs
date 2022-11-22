using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEndZone
{
    public void Damage(float a, IKillable b);
    public void AttackAgressor(IKillable b);
}
