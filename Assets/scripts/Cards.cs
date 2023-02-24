using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour, IDamageable<float>, IKillable, IObstacle
{
    [SerializeField]
    float _Health;
    [SerializeField]
    float _MaxHealth;
    [SerializeField]
    public float damage;
    public int _Cost;   
    public Sprite AssignedCard;
    [SerializeField]
    int _gift;

    public ParticleSystem DeathPartycle;

    

    private void Awake()
    {
        //gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
    }

    private void Start()
    {
        _Health = _MaxHealth;
        _gift = _Cost / 10;
        Debug.Log(_Health);
        DeathPartycle.Pause();
    }
    virtual public void Shoot()
    {

    }

    

    public virtual void Damage(float damageTaken)
    {
        Debug.Log(_Health);
        _Health -= damageTaken;
       
        if (_Health <= 0)
        {        
            Death();
        }
    }

    public void Death()
    {       
        UpdateMoney.updatemoney.ActMoney(_gift);
        StartCoroutine(ReEnableCooldown());
    }

    private IEnumerator ReEnableCooldown()
    {
        MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        Light[] light = gameObject.GetComponentsInChildren<Light>();
        DeathPartycle.Play();
        foreach (var a in light)
        {
            Destroy(a);
        }
        foreach(var a in meshRenderers)
        {
            Destroy(a);
        }
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
        yield return new WaitForSeconds(5);
        GetComponentInParent<Tile>()?.CanInteractToggle();
        //DeathPartycle.Play();
        Destroy(gameObject);
    }
}
