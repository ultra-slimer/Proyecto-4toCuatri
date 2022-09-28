using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
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
}
