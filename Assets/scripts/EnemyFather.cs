using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFather : MonoBehaviour, IAttack, IDamageable<float>, IKillable
{
    [SerializeField]
    float _life;
    [SerializeField]
    float _speed;
    [SerializeField]
    float _attackSpeed;
    [SerializeField]
    float _time;
    [SerializeField]
    float _damage;

    public Transform[] allWaypoints;

    bool _canWalk;
    int _layerMask;

    /*[SerializeField]
    Cards C;*/

    

    private void Awake()
    {
        _time = 0;
        _canWalk = true;
        _layerMask = LayerMask.GetMask("Unit");
    }

    void Update()
    {
        if(_canWalk)
        {
            Transform nextWaypoint = allWaypoints[0];
            Vector3 dir = nextWaypoint.position - transform.position;
            dir.y = 0;
            transform.forward = dir;
            transform.position += transform.forward * _speed * Time.deltaTime;
        }

        
        Attack();
    }

    public void Attack()
    {

        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        //Debug.DrawRay(this.transform.position, this.transform.forward, Color.yellow);
        if (Physics.Raycast(ray, out hit, 1f, _layerMask))
        {
            
           _time += Time.deltaTime;
            _canWalk = false;
            if (_attackSpeed <= _time)
            {
                _time = 0;

                //Cards pipo = Cards.Instance();
                //GetComponent<Cards>().Damage(_damage);
                //C.Damage(_damage);

                TestCubo temp = hit.collider.GetComponent<TestCubo>();
                if (temp)
                {
                    temp.enemy = this;
                }
                hit.collider.GetComponent<Cards>().Damage(_damage);
            }
        }
        else _canWalk = true;
    }

    public virtual void Damage(float damageTaken)
    {
        _life -= damageTaken;

        if(_life <= 0) 
            Death();
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
