using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour, ISpawner<Gems>
{
    public Gems gems;
    static ObjectPool<Gems> _pool;
    static Factory<Gems> _factory;
    public static GemSpawner gemSpawner;

    void Start()
    {
        gemSpawner = this;
        _factory = new Factory<Gems>(gems);
        _pool = new ObjectPool<Gems>(_factory.Get, Gems.Enable, Gems.Disable, 3);
    }
    /*public Gems Factory()
    {
        Gems temp = Instantiate(gems);
        temp.ISpawnable<Gems>. = temp;
        return temp;
    }*/
    void Update()
    {

    }

    public Gems GetOne()
    {
        gems = _pool.GetObject();
        gems.Create(_pool);
        return gems;
    }

    public void EndOne(Gems b)
    {
        _pool.ReturnObject(b);
    }
}
