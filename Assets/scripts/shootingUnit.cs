using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingUnit : Cards
{
    public float fireRate;
    public GameObject Projectile;
    public delegate void actions();
    private actions shoot = delegate { };
    private float time;
    public Transform block;
    public BulletSpawner bulletSpawner;

    private void Awake()
    {
        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= fireRate)
        {
            shoot = delegate
            {
                //GameObject clone = Instantiate(Projectile, block);
                //clone.GetComponent<Rigidbody>().velocity = block.TransformDirection(Vector3.right * 20);
                //Projectile.transform.position = transform.position;
                //Projectile.SetActive(true);
                //Destroy(clone, 3);
                StartCoroutine("ShootBullet");
            };
            time = 0;
        }
        else
        {
            shoot = delegate { };
        }
        shoot();
    }
    private IEnumerator ShootBullet()
    {
        Bullet temp = bulletSpawner.GetOne();
        temp.transform.position = transform.position;
        yield return new WaitForSeconds(fireRate - 2f);
        bulletSpawner.EndOne(temp);
    }

}

