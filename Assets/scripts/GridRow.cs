using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRow : MonoBehaviour
{
    public Tile[] cells { get; private set; }
    private void Awake()
    {
        cells = GetComponentsInChildren<Tile>();
    }
}
