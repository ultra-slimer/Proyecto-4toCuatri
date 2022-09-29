using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubo : Cards
{
    public LayerMask layerMask;
    public EnemyFather enemy;
    private void OnCollisionEnter(Collision collision)
    {
        if ((layerMask.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            try
            {
                enemy = collision.gameObject.GetComponent<EnemyFather>();
            }
            catch
            {
                Debug.LogError("No Enemy in the collider, maybe collider is in different object or wrong layer used");
            }
        }
    }
    public override void Damage(float damageTaken)
    {
        enemy.Damage(damage);
        base.Damage(damageTaken);
    }
}
