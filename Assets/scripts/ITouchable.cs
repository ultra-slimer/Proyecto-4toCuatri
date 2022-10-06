using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable
{
    public abstract void Touched(RaycastHit hit);
}
