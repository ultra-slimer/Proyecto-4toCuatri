using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour, IDamageable<float>
{
    [SerializeField]
    float _Health;
    [SerializeField]
    float _MaxHealth;
    [SerializeField]
    float _Damage;
    public int _Cost;   
    public Sprite AssignedCard;

    

    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
    virtual public void Shoot()
    {

    }

    

    public void Damage(float damageTaken)
    {
        _Health -= damageTaken;

        if (_Health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {

    }
}
