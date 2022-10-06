using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable<T>
{
    T _prefab;

    public Factory(T stuff) => _prefab = stuff;
    public T Get()
    {
        T temp = GameObject.Instantiate(_prefab);
        temp.SaveThing(temp);
        return temp;
    }
}
