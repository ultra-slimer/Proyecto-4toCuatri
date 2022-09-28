using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Bullet bullet;
    ObjectPool<Bullet> _pool;

    private void Start()
    {
        _pool = new ObjectPool<Bullet>(Factory, Bullet.EnableBullet, Bullet.DisableBullet, 10);
    }

    public Bullet Factory()
    {
        return Instantiate(bullet);
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
