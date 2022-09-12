using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    [SerializeField]
    float _Health;
    [SerializeField]
    float _MaxHealth;
    [SerializeField]
    float _Damage;
    [SerializeField]
    int _Cost;
    

    virtual public void Shoot()
    {

    }

    public void Death()
    {

    }


}
