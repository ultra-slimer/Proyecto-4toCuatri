using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawner<EnemyFather>
{
    [SerializeField]
    float _frequencyEnemies;
    public GameObject _enemy;
    private float _counter;


    public EnemyFather enemyFather;
    ObjectPool<EnemyFather> _pool;
    Factory<EnemyFather> _factory;

    void Start()
    {
        enemyFather = _enemy.GetComponent<EnemyFather>();
        _factory = new Factory<EnemyFather>(enemyFather);
        _pool = new ObjectPool<EnemyFather>(_factory.Get, SmartEnemy.Enable, SmartEnemy.Disable, 10);
    }
    public bool canSpawn;

    public Transform[] spawnPoints;
    [HideInInspector]
    int _randomSpawn;


    private void Update()
    {
        _counter += Time.deltaTime;
        if (_counter >= _frequencyEnemies && gameObject.activeSelf)
        {
            GetOne();
            _counter = 0;
        }
    }



    /*IEnumerator Start()
    {
        while (canSpawn)
        {
            //apenas inicia el juego
            yield return new WaitForSeconds(_frequencyEnemies);

            _randomSpawn = Random.Range(0, 5);
            print("spawneo en pos " + _randomSpawn);
            print("Enemy " + GameManager.instance.Enemy);
            GameManager.instance.Enemy.waypointTarget = _randomSpawn;
            
            GameObject _insEnemy = Instantiate(_enemy, spawnPoints[_randomSpawn].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        }
    }*/

    public EnemyFather GetOne()
    {
        enemyFather = _pool.GetObject();
        var temp = Random.Range(0, 5);
        enemyFather.waypointTarget = temp;
        enemyFather.transform.position = spawnPoints[temp].position;
        return enemyFather;
    }

    public void EndOne(EnemyFather one)
    {
        _pool.ReturnObject(one);
    }
}
