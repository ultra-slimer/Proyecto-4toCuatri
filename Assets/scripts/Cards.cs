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

    

    private void Awake()
    {
        //gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
    }

    private void Start()
    {
        _Health = _MaxHealth;
        Debug.Log(_Health);
       
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
        StartCoroutine(ReEnableCooldown());
    }

    private IEnumerator ReEnableCooldown()
    {
        Destroy(gameObject.GetComponent<MeshRenderer>());
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        yield return new WaitForSeconds(3);
        GetComponentInParent<Tile>()?.CanInteractToggle();
        Destroy(gameObject);
    }
}
