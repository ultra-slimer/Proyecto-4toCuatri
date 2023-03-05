using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFather : Spawnables<EnemyFather, ISpawner<EnemyFather>>, IAttack, IDamageable<float>, IKillable, IObstacle, ISpawnable<EnemyFather>
{
    public string[] ReactingLayers = { "Unit", "Enemy", "EndZone" };
    [SerializeField]
    float _life;
    [SerializeField]
    public float _speed;
    [SerializeField]
    public float _attackSpeed;
    [SerializeField]
    public float _time;
    [SerializeField]
    public float _damage;
    [SerializeField]
    int _reward;
    [SerializeField]
    public Animator _anim;
    [SerializeField]
    public float damageMultiplier;

    public Transform[] allWaypoints;
    public int waypointTarget;

    private EnemyFather _self;

    public bool _canWalk;
    public int _layerMask;

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
    private void OnEnable()
    {
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

        
        EnemyAction();
    }

    public virtual void EnemyAction()
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
                    print("a");
                    hit.collider.GetComponent<IEndZone>().Damage(1, this);

                }
                else
                {

                    hit.collider.GetComponent<IDamageable<float>>().Damage(_damage);
                    AudioManager.Instance().Play("EnemyAttack");
                }
                hit.collider.GetComponent<IAttackBack>()?.AttackAgressor(_damage, this);
            }
        }
        else _canWalk = true;
    }

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
