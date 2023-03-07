using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFather : Spawnables<EnemyFather, ISpawner<EnemyFather>>, IAttack, IDamageable<float>, IKillable, IObstacle, ISpawnable<EnemyFather>
{
    public string[] ReactingLayers = { "Unit", "Enemy", "EndZone" };
    [SerializeField]
    public float _life;
    [SerializeField]
    public float _speed;
    [SerializeField]
    public float _attackSpeed;
    [SerializeField]
    public float _time;
    [SerializeField]
    public float _damage;
    [SerializeField]
    public int _reward;
    [SerializeField]
    public Animator _anim;
    [SerializeField]
    public float damageMultiplier;
    [SerializeField]
    public Flyweight flyweight;
    private float _OGLife;

    public Transform[] allWaypoints;
    public int waypointTarget;

    private EnemyFather _self;

    public bool _canWalk;
    public int _layerMask;

    public ParticleSystem DamagePartycle;

    /*[SerializeField]
    Cards C;*/

    

    public virtual void Awake()
    {
        _canWalk = true;
        _layerMask = LayerMask.GetMask(ReactingLayers);
        _self = this;
        DamagePartycle.Pause();
       
    }
    public virtual void OnEnable()
    {
        DamagePartycle.Pause();
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

        
        EnemyAction();
    }

    public virtual void EnemyAction() { }

    public virtual void Damage(float damageTaken, float multiplier = 1)
    {
        _life -= damageTaken;
        Instantiate(DamagePartycle, this.transform);

        if (_life <= 0)
        {
            //print(_self);
            AudioManager.Instance().Stop("EnemyAttack");
            AudioManager.Instance().Play("EnemyDeath");
            _self.Death();
        }
    }

    public virtual void Death()
    {
        int a;
        if (GameSave._increasedGemChance)
        {
            a = Random.Range(1, 5);
        }
        else
        {
            a = Random.Range(1, 10);
        }
        if(a == 1)
        {
            GemSpawner.gemSpawner.GetOne().transform.position = transform.position;
        }
        UpdateMoney.updatemoney.ActMoney(_reward);
        //Destroy(gameObject);
        _referenceBack.ReturnObject(this);
    }

    
}
