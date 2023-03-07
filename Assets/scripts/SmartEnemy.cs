using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : EnemyFather, ISpawnable<SmartEnemy>
{
    public void SaveThing(SmartEnemy newThing)
    {
        self = newThing;
    }
    public override void Awake()
    {
        base.Awake();
    }
    public override void OnEnable()
    {
        base.OnEnable();
        _life = flyweight.maxLife;
        _time = flyweight.time;
    }
    private void Start()
    {
        flyweight = FlyweightPointer.BaseEnemy;
        _life = flyweight.maxLife;
        _damage = flyweight.damage;
        _speed = flyweight.speed;
        _reward = flyweight.reward;
        _time = flyweight.time;
    }
    public override void EnemyAction()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.yellow);
        if (Physics.Raycast(ray, out hit, 1f, _layerMask))
        {

            this._time += Time.deltaTime;
            _anim.SetBool("_isFollowing", false);
            _canWalk = false;
            if (_attackSpeed <= this._time && hit.transform.GetComponent<IDamageable<float>>() != null && hit.transform.GetComponent<EnemyFather>() == null)
            {
                this._time = 0;

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

                    hit.collider.GetComponent<IDamageable<float>>().Damage(this._damage);
                    AudioManager.Instance().Play("EnemyAttack");
                }
                hit.collider.GetComponent<IAttackBack>()?.AttackAgressor(this._damage, this);
            }
        }
        else _canWalk = true;
    }
}
