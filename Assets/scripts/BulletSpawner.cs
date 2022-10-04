using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public Bullet bullet;
    ObjectPool<Bullet> _pool;
    Factory<Bullet> _factory;

    void Start()
    {
        _factory = new Factory<Bullet>(bullet);
        _pool = new ObjectPool<Bullet>(_factory.Get, Bullet.EnableBullet, Bullet.DisableBullet, 20);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var b = _pool.GetObject();
            b.Create(_pool);
            b.transform.position = transform.position;
            b.transform.forward = transform.forward;
        }
    }

    public Bullet GetOne()
    {
        bullet = _pool.GetObject();
        if (!bullet.bulletSpawner)
        {
            bullet.SetBulletSpawner(this, bullet);
        }
        return bullet;
    }

    public void EndOne(Bullet b)
    {
        _pool.ReturnObject(b);
    }
}
