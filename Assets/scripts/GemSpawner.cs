using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour, ISpawner<Gems>
{
    public Gems gems;
    ObjectPool<Gems> _pool;

    void Start()
    {
        _pool = new ObjectPool<Gems>(Factory, Gems.Enable, Gems.Disable, 3);
    }
    public Gems Factory()
    {
        Gems temp = Instantiate(gems);
        temp.thing = temp;
        return temp;
    }
    void Update()
    {

    }

    public Gems GetOne()
    {
        gems = _pool.GetObject();
        if (!gems.spawner)
        {
            gems.SetSpawner(this, gems);
            gems.Create(_pool);
        }
        return gems;
    }

    public void EndOne(Gems b)
    {
        _pool.ReturnObject(b);
    }
}
