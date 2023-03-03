using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float damage;
    public Rigidbody rb;
    public LayerMask allowedCollisions;


 
    private void OnCollisionEnter(Collision collision)
    {
        print("AAAAAAA");

        if ((allowedCollisions.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {

            var temp = collision.gameObject.GetComponent<EnemyFather>();
            if (temp)
            {
                temp.Damage(damage);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        print("AAAAAAA");

        if ((allowedCollisions.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {

            var temp = collision.gameObject.GetComponent<EnemyFather>();
            if (temp)
            {
                temp.Damage(damage);
            }
        }
    }



    private void Awake()
    {
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Unit"));
    }
}
