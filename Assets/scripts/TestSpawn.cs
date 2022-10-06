using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    [SerializeField]
    float _frequencyEnemies;
    public GameObject _enemy;

    public bool canSpawn;

    public Transform[] spawnPoints;
    [HideInInspector]
    int _randomSpawn;
   

    public void Awake()
    {
        
    }

    

    IEnumerator Start()
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
    }






}
