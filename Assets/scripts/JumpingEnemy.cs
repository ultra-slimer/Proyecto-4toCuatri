using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : EnemyFather, ISpawnable<JumpingEnemy>
{

    bool _allowedJump = true;
    public float jumpHeight;
    [SerializeField] Rigidbody _enemRB;


    public override void EnemyAction()
    {
        if (_allowedJump)
        {
            StartCoroutine("UseSpecialAbility");
        }
        else
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
            else _canWalk = true;
        }
       

       

    }

    private IEnumerator UseSpecialAbility()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;
        //Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);

        if (Physics.Raycast(ray, out hit, 0.5f, _layerMask))
        {
            _enemRB.AddForce(new Vector2(-waypointTarget, jumpHeight), ForceMode.Force);

            yield return new WaitForSeconds(0.5f);

            
            _speed = 0.75f;
            _allowedJump = false;
            print("a");
        }

        yield break;

        
    }

    public void SaveThing(JumpingEnemy newThing)
    {
        self = newThing;
    }
}
