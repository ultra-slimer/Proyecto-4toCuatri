using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawner<EnemyFather>
{
    [SerializeField]
    float _frequencyEnemies;
    private float _OGFreq;
    public GameObject _enemy;
    private float _counter;
    [Range(1.5f, 3)]
    public float minSpawnRate;
    [Range(0, 0.5f)]
    public float increaseRatePercentage = 0.1f;
    public int spawnAmount;
    private bool won = false;
    private delegate void spawn();
    private spawn spawnAction;


    public EnemyFather enemyFather;
    ObjectPool<EnemyFather> _pool;
    Factory<EnemyFather> _factory;

    void Start()
    {
        _OGFreq = _frequencyEnemies;
        enemyFather = _enemy.GetComponent<EnemyFather>();
        _factory = new Factory<EnemyFather>(enemyFather);
        _pool = new ObjectPool<EnemyFather>(_factory.Get, SmartEnemy.Enable, SmartEnemy.Disable, 10);
        if(_frequencyEnemies == 0)
        {
            spawnAction = delegate { };
        }
        else
        {
            spawnAction = delegate
            {
                _counter += Time.deltaTime;
                if (_counter >= _frequencyEnemies && gameObject.activeSelf && spawnAmount > 0)
                {
                    _frequencyEnemies = Mathf.Clamp(_frequencyEnemies * (100 - (100 * increaseRatePercentage)) * 0.01f, minSpawnRate, _OGFreq);
                    print(_frequencyEnemies);
                    GetOne();
                    _counter = 0;
                    spawnAmount -= 1;
                }
                else if (spawnAmount == 0 && FindObjectsOfType<SmartEnemy>().Length == 0 && !won)
                {
                    GameStateManager.gameStateManager.WonGame();
                    won = true;
                }
            };
        }
    }
    public bool canSpawn;

    public Transform[] spawnPoints;
    [HideInInspector]
    int _randomSpawn;


    private void Update()
    {
        spawnAction();
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
        enemyFather.Create(_pool);
        return enemyFather;
    }

    public EnemyFather GetOne(int waypoint)
    {
        enemyFather = _pool.GetObject();
        enemyFather.waypointTarget = waypoint;
        enemyFather.transform.position = spawnPoints[waypoint].position;
        enemyFather.Create(_pool);
        return enemyFather;
    }

    public void EndOne(EnemyFather one)
    {
        _pool.ReturnObject(one);
    }
}
