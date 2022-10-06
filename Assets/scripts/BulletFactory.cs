using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public Bullet prefab;

    public enum Type
    {
        Normal,
        Explosion
    }

    public Bullet Get(Type type)
    {
        //Dependiendo el enum instancio una bala u otra.
        //Puedo tener un array de Bullet y ahi cargar los diferentes tipos de balas.
        Bullet b = Instantiate(prefab);
        b.thing = b;
        return b;
    }
}
