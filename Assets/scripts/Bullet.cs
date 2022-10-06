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
        _counter += Time.deltaTime;
        base.Update();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((allowedCollisions.value & 1<<collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            try
            {
                var temp = collision.gameObject.GetComponent<EnemyFather>();
                temp.Damage(damage);
            }
            catch (Exception e)
            {
                //Debug.LogError($"No Enemy in the collider, maybe collider is in different object or wrong layer used, Collided With {collision.gameObject.name}");
                Debug.LogError(e);
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
