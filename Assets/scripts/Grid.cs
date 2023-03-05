using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GridRow[] rows { get; private set; }
    public Tile[] cells { get; private set; }
    public List<Material> materials;
    public List<Tile> tiles;
    public int size => cells.Length;
    public int height => rows.Length;
    public int width => size / height;

    public Material GetMaterial(int i)
    {
        return materials[i];
    }

    private void Start()
    {
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows[i].cells.Length; j++)
            {
                rows[i].cells[j].coordinates = new Vector2Int(i, j);
            }
        }
    }
    private void Awake()
    {
        rows = GetComponentsInChildren<GridRow>();
        cells = GetComponentsInChildren<Tile>();
    }
}
