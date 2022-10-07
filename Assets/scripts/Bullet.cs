using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Bullet : Spawnables<Bullet, BulletSpawner>
{
    public Rigidbody rb;
    public int speed;
    public LayerMask allowedCollisions;
    public float damage;


    public override void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        base.Update();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((allowedCollisions.value & 1<<collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            var temp = collision.gameObject.GetComponent<EnemyFather>();
            if (temp)
            {
                temp.Damage(damage);
            }
            //bulletSpawner.EndOne(this);
            print("se devuelve bala por colision");
            print(_referenceBack);
            _referenceBack.ReturnObject(this);
        }
    }
    private void Awake()
    {
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Unit"));
    }
}
