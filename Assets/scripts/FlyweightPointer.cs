using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    //Enemigo base stats
    public static readonly Flyweight BaseEnemy = new Flyweight
    {
        maxLife = 15,
        speed = 0.75f,
        attackSpeed = 1.5f,
        reward = 25,
        damage = 5,
        time = 0

    };

    //Enemigo que salta (todavia no implementado)
    public static readonly Flyweight JumpEnemy = new Flyweight
    {
        maxLife = 0,
        speed = 0,
        attackSpeed = 0,
        reward = 0,
        damage = 0

    };

}
   

