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
    

    virtual public void Shoot()
    {

    }

    public void Death()
    {

    }


}
