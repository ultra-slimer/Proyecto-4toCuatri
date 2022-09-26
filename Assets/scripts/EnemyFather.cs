using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFather : MonoBehaviour
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

    private void Awake()
    {
        _time = 0;
    }

    void Update()
    {
        Transform nextWaypoint = allWaypoints[0];
        Vector3 dir = nextWaypoint.position - transform.position;
        dir.y = 0;
        transform.forward = dir;
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
