using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour, IObstacle, IDamageable<float>, IEndZone, IAttackBack
{
    public float life = 3;
    private bool lost = false;

    public void AttackAgressor(float damage, IDamageable<float> agressor)
    {
        agressor.Damage(999);
    }

    public void Damage(float damageTaken)
    {
        life -= 1;
        if(life <= 0 && !lost)
        {
            GameStateManager.gameStateManager.LostGame();
            lost = true;
        }
    }

}
