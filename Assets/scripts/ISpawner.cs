using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ISpawner<T> where T : MonoBehaviour, ISpawnable<T>
{
    public T GetOne();
    public void EndOne(T one);
}
