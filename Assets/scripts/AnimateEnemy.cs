using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEnemy : MonoBehaviour
{
    public Animator anim;

    public AnimateEnemy animateEnemy;


    public void Awake()
    {
        animateEnemy = this;
    }
   

    public void Walk()
    {
        anim.SetBool("_isFollowing", true);
        anim.SetBool("_isAttacking", false);
    }

    public void Attack()
    {
        anim.SetBool("_isAttacking", true);
        anim.SetBool("_isFollowing", false);
    }

    public void Death()
    {
        anim.SetFloat("health", 0);

        anim.SetBool("_isFollowing", false);
        anim.SetBool("_isAttacking", false);
    }
}
