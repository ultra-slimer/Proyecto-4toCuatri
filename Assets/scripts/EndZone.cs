using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour, IObstacle, IEndZone, IDamageable<float>
{
    public float life = 3;
    private bool lost = false;

    public void AttackAgressor(IKillable agressor)
    {
        agressor.Death();
    }

    public void Damage(float damageTaken, IKillable killable)
    {
        life -= 1;
        killable.Death();
        if(life <= 0 && !lost)
        {
            GameStateManager.gameStateManager.LostGame();
            lost = true;
        }
    }

    public void Damage(float damageTaken)
    {
        throw new System.NotImplementedException();
    }
}
