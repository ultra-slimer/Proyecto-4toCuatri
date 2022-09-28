using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
    public BulletSpawner bulletSpawner;
    public LayerMask allowedCollisions;
    public static void EnableBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.rb.velocity = bullet.transform.TransformDirection(Vector3.right * bullet.speed);
    }
    public static void DisableBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.rb.velocity = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((allowedCollisions.value & 1<<collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            bulletSpawner.EndOne(this);
        }
    }
    public void SetBulletSpawner(BulletSpawner spawner, Bullet bullet)
    {
        bullet.bulletSpawner = spawner;
    }
}
