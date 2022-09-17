using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField]
    float _Health;
    [SerializeField]
    float _MaxHealth;
    [SerializeField]
    float _Damage;
    [SerializeField]
    int _Cost;   
    public Sprite AssignedCard;

    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
    virtual public void Shoot()
    {

    }

    public void Death()
    {

    }


}
