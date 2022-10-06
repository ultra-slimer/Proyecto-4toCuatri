using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is here in case i need to remember how to do this shit
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
        //b.ISpawnable = b;
        return b;
    }
}
