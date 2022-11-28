using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFather : Spawnables<EnemyFather, ISpawner<EnemyFather>>, IAttack, IDamageable<float>, IKillable, IObstacle, ISpawnable<EnemyFather>
{
    public string[] ReactingLayers = { "Unit", "Enemy", "EndZone" };
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
    [SerializeField]
    int _reward;
    [SerializeField]
    Animator _anim;

    public Transform[] allWaypoints;
    public int waypointTarget;

    private EnemyFather _self;

    bool _canWalk;
    int _layerMask;

    public ParticleSystem DamagePartycle;

    /*[SerializeField]
    Cards C;*/

    

    private void Awake()
    {
        _time = FlyweightPointer.BaseEnemy.time;
        _canWalk = true;
        _layerMask = LayerMask.GetMask(ReactingLayers);
        _self = this;
        DamagePartycle.Pause();
       
    }

    public void Start()
    {
        _life = FlyweightPointer.BaseEnemy.maxLife;
        _damage = FlyweightPointer.BaseEnemy.damage;
        _reward = FlyweightPointer.BaseEnemy.reward;
        _attackSpeed = FlyweightPointer.BaseEnemy.attackSpeed;
        _speed = FlyweightPointer.BaseEnemy.speed;
    }

    public override void Update()
    {
        if(_canWalk)
        {
            Transform nextWaypoint = allWaypoints[waypointTarget];
            Vector3 dir = nextWaypoint.position - transform.position;
            dir.y = 0;
            transform.forward = dir;
            transform.position += transform.forward * _speed * Time.deltaTime;

            _anim.SetBool("_isFollowing", true);
            _anim.SetBool("_isAttacking", false);

        }

        
        Attack();
    }

    public void Attack()
    {

        var ray = new Ray(this.transform.position, this.transform.forward);
       
        RaycastHit hit;
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.yellow);
        if (Physics.Raycast(ray, out hit, 1f, _layerMask))
        {
           
            _time += Time.deltaTime;
            _anim.SetBool("_isFollowing", false);
            _canWalk = false;
            if (_attackSpeed <= _time && hit.transform.GetComponent<IDamageable<float>>() != null && hit.transform.GetComponent<EnemyFather>() == null)
            {
                _time = 0;

                _anim.SetBool("_isAttacking", true);
                //Cards pipo = Cards.Instance();
                //GetComponent<Cards>().Damage(_damage);
                //C.Damage(_damage);

                if (hit.collider.GetComponent<IEndZone>() != null)
                {
                  
                    hit.collider.GetComponent<IEndZone>().Damage(1, this);

                }
                else
                {

                    hit.collider.GetComponent<IDamageable<float>>().Damage(_damage);
                }
                hit.collider.GetComponent<IAttackBack>()?.AttackAgressor(_damage, this);
            }
        }
        else _canWalk = true;
    }

    public virtual void Damage(float damageTaken)
    {
        _life -= damageTaken;
        Instantiate(DamagePartycle, this.transform);

        if (_life <= 0)
        {
            //print(_self);
            _self.Death();
        }
    }

    public virtual void Death()
    {
       
        int a = Random.Range(1, 10);
        if(a == 1)
        {
            GemSpawner.gemSpawner.GetOne().transform.position = transform.position;
        }
        UpdateMoney.updatemoney.ActMoney(_reward);
        //Destroy(gameObject);
        _referenceBack.ReturnObject(this);
    }

    
}
