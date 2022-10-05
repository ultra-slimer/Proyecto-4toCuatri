using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;
    public BulletSpawner bulletSpawner;
    public LayerMask allowedCollisions;
    public int maxTime;
    public float damage;
    float _counter;


    ObjectPool<Bullet> _referenceBack;
    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        _counter += Time.deltaTime;

        if (_counter >= maxTime && gameObject.activeSelf)
        {
            print("se devuelve bala por tiempo");
            _referenceBack.ReturnObject(this);
        }
    }
    public static void EnableBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }
    public static void DisableBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.ResetBullet();
        bullet.rb.velocity = new Vector3(0, 0, 0);
    }
    public void ResetBullet()
    {
        _counter = 0;
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
        bullet.bulletSpawner = spawner;
    }
    public void Create(ObjectPool<Bullet> op)
    {
        _referenceBack = op;
    }
    private void Awake()
    {
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Unit"));
    }
}
