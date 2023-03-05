using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Cards, IAttack
{
    private AudioSource _audioSource;
    public GameObject flame;
    private float time;
    public float fireRate;

   

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= fireRate)
        {                                             
            EnemyAction();
        }
        
    }

    
    private IEnumerator _ShootFire()
    {
        flame.SetActive(true);
        //_audioSource.Play();
        //print(damage);        
        if (_Health <= 0)
        {
            flame.SetActive(false);
        }
        yield return new WaitForSeconds(4);
        time = 0;
        flame.SetActive(false);
    } 

    public void EnemyAction()
    {
        StartCoroutine("_ShootFire");
    }
}
