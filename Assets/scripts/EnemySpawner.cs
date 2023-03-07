using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawner<EnemyFather>
{
    [SerializeField]
    float _frequencyEnemies;
    private float _OGFreq;
    public List<EnemyFather> _enemys;
    private float _counter;
    [Range(1.5f, 3)]
    public float minSpawnRate;
    [Range(0, 0.5f)]
    public float increaseRatePercentage = 0.1f;
    public List<int> spawnAmount;
    private bool won = false;
    private delegate void spawn();
    private spawn spawnAction;
    private int totalEnemies;

    List<ObjectPool<EnemyFather>> _pool = new List<ObjectPool<EnemyFather>>();
    List<Factory<EnemyFather>> _factory = new List<Factory<EnemyFather>>();

    void Start()
    {
        for (int i = 0; i < _enemys.Count; i++)
        {
            PrepareSpawner(_enemys[i]);
            totalEnemies = spawnAmount[i];
        }
        if(_frequencyEnemies == 0)
        {
            spawnAction = delegate { };
        }
        else
        {
            spawnAction = delegate
            {
                _counter += Time.deltaTime;
                if (_counter >= _frequencyEnemies && gameObject.activeSelf && totalEnemies > 0)
                {
                    bool _spawned = false;
                    while (!_spawned)
                    {
                        var a = Random.Range(0, spawnAmount.Count);
                        if(_enemys[a] && spawnAmount[a] > 0)
                        {
                            _frequencyEnemies = Mathf.Clamp(_frequencyEnemies * (100 - (100 * increaseRatePercentage)) * 0.01f, minSpawnRate, _OGFreq);
                            SpawnEnemy(a);
                            _spawned = true;
                        }
                    }
                }
                else if (totalEnemies == 0 && FindObjectsOfType<EnemyFather>().Length == 0 && !won)
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

    public void PrepareSpawner(EnemyFather enemy)
    {
        _OGFreq = _frequencyEnemies;
        var temp = new Factory<EnemyFather>(enemy);
        _factory.Add(temp);
        _pool.Add( new ObjectPool<EnemyFather>(temp.Get, EnemyFather.Enable, EnemyFather.Disable, 2));
    }

    private void SpawnEnemy(int enemyID)
    {
        GetOne(enemyID);
        _counter = 0;
        if(spawnAmount[enemyID] > 0)
        {
            spawnAmount[enemyID] -= 1;
            totalEnemies -= 1;
        }
        else
        {
            _enemys.RemoveAt(enemyID);
            spawnAmount.RemoveAt(enemyID);
            _factory.RemoveAt(enemyID);
            _pool.RemoveAt(enemyID);
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

    public EnemyFather GetOne(int enemyID)
    {
        var enemyFather = _pool[enemyID].GetObject();
        var temp = Random.Range(0, 5);
        enemyFather.waypointTarget = temp;
        enemyFather.transform.position = spawnPoints[temp].position;
        enemyFather.Create(_pool[enemyID]);
        return enemyFather;
    }

    public EnemyFather GetOne(int enemyID, int waypoint)
    {
        var enemyFather = _pool[enemyID].GetObject();
        enemyFather.waypointTarget = waypoint;
        enemyFather.transform.position = spawnPoints[waypoint].position;
        enemyFather.Create(_pool[enemyID]);
        return enemyFather;
    }

    public void EndOne(int enemyID, EnemyFather one)
    {
        _pool[enemyID].ReturnObject(one);
    }

    public EnemyFather GetOne()
    {
        throw new System.NotImplementedException();
    }

    public void EndOne(EnemyFather one)
    {
        throw new System.NotImplementedException();
    }
}
