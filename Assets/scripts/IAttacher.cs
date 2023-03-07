using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacher<T>
{
    public void Attach(T attachee);
    public void Deattach();
}
