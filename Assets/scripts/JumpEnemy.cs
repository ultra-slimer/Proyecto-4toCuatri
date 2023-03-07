using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : EnemyFather, ISpawnable<JumpEnemy>
{

    bool _allowedJump = true;
    public float jumpHeight;
    [SerializeField] 
    Rigidbody _enemRB;


    private void Start()
    {
        flyweight = FlyweightPointer.JumpEnemy;
        _life = flyweight.maxLife;
        _damage = flyweight.damage;
        _speed = flyweight.speed;
        _reward = flyweight.reward;
        _time = flyweight.time;
    }
    public override void EnemyAction()
    {
        if (_allowedJump)
        {
            var ray = new Ray(this.transform.position, this.transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 0.5f, _layerMask) && hit.transform.GetComponent<EnemyFather>() == null)
            {
                var a = hit.transform.GetComponent<Cards>();
                if (!Grid.GetNeighbor(a.tile, Vector2Int.left).occupied)
                {
                    StartCoroutine("UseSpecialAbility");
                }
                else 
                {
                    Attack();
                }
              
            
                //StartCoroutine("UseSpecialAbility");
                
            }
            //StartCoroutine("UseSpecialAbility");
        }
        else
        {
            Attack();
        }

        

    }

    public void Attack()
    {
        _allowedJump= false;

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
                    //print("a");
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
        else
        {
            _canWalk = true;
            //_allowedJump = true;
        }
        
       
    }

    private IEnumerator UseSpecialAbility()
    {
        _enemRB.AddForce(new Vector2(-waypointTarget, jumpHeight), ForceMode.Force);

        yield return new WaitForSeconds(0.5f);


        _speed = 0.75f;
        _allowedJump = false;
        print("a");

        yield break;

        
    }

    public void SaveThing(JumpEnemy newThing)
    {
        self = newThing;
    }
}
