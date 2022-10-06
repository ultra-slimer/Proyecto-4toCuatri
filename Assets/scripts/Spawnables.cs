using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Spawnables<T, U> : MonoBehaviour
{
    public float _counter;
    public int maxTime;
    public U spawner;
    public T thing;
    ObjectPool<T> _referenceBack;


    // Update is called once per frame
    public virtual void Update()
    {
        _counter += Time.deltaTime;
        if (_counter >= maxTime && gameObject.activeSelf)
        {
            //print("Se devuelve objeto");
            _referenceBack.ReturnObject(thing);
        }

    }
    public void SetSpawner(U spawner, Spawnables<T, U> obj)
    {
        obj.spawner = spawner;
    }
    public void Create(ObjectPool<T> op)
    {
        _referenceBack = op;
    }
    public void ResetCounter()
    {
        _counter = 0;
    }
    public static void Enable(Spawnables<T, U> obj)
    {
        obj.gameObject.SetActive(true);
    }
    public static void Disable(Spawnables<T, U> obj)
    {
        obj.gameObject.SetActive(false);
        obj.ResetCounter();
    }
}

