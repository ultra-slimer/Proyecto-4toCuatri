using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Spawnables<Bullet, BulletSpawner>
{
    public Rigidbody rb;
    public int speed;
    public LayerMask allowedCollisions;
    public float damage;


    ObjectPool<Bullet> _referenceBack;
    private void OnDisable()
    {
        thing = this;
    }
    private void Start()
    {
        thing = this;
    }
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
                collision.gameObject.GetComponent<EnemyFather>().Damage(damage);
            }
            catch
            {
                Debug.LogError("No Enemy in the collider, maybe collider is in different object or wrong layer used");
            }
            //bulletSpawner.EndOne(this);
            print("se devuelve bala por colision");
            print(_referenceBack);
            _referenceBack.ReturnObject(this);
        }
    }
    public void SetBulletSpawner(BulletSpawner spawner, Bullet bullet)
    {
        bullet.spawner = spawner;
    }
    private void Awake()
    {
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Unit"));
    }
}
