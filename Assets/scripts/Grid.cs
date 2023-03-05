using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GridRow[] rows { get; private set; }
    public Tile[] cells { get; private set; }
    public List<Material> materials;
    public int size => cells.Length;
    public int height => rows.Length;
    public int width => size / height;
    public static Grid instance;
    public Material GetMaterial(int i)
    {
        return materials[i];
    }
    private void Start()
    {
        instance = this;
        rows = GetComponentsInChildren<GridRow>();
        cells = GetComponentsInChildren<Tile>();
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows[i].cells.Length; j++)
            {
                rows[i].cells[j].coordinates = new Vector2Int(j, i);
            }
        }
    }
    
    public static Tile GetNeighbor(Tile baseTile, Vector2Int direction)
    {
        Vector2Int a = baseTile.coordinates;
        a.x += direction.x;
        a.y -= direction.y;
        return Grid.instance.GetCell(a.x, a.y);
    }
    private Tile GetCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return rows[y].cells[x];
        }
        else
        {
            return null;
        }
    }
}
