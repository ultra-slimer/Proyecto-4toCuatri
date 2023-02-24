using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
    private TileGrid grid;
    public TileState[] tileStates;
    private List<MiniGameTile> tiles;
    public MiniGameTile tilePrefab;
    private void Awake()
    {
        grid = GetComponentInChildren<TileGrid>();
        tiles = new List<MiniGameTile>();
    }
    private void Start()
    {
        CreateTile();
        CreateTile();
    }

    private void CreateTile()
    {
        MiniGameTile tile = Instantiate(tilePrefab, grid.transform);
        int randomNumber;
        var a = Random.value;
        if(a < 0.8f)
        {
            randomNumber = 2;
        }
        else if(a < 0.95f)
        {
            randomNumber = 4;
        }
        else
        {
            randomNumber = 8;
        }
        tile.SetState(tileStates[0], randomNumber);
        tile.Spawn(grid.GetRandomEmptyCell());
        tiles.Add(tile);
    }

    public void MoveTiles(Vector2Int direction, int startX, int incrementX, int startY, int incrementY)
    {
        for (int x = startX; x >= 0 && x < grid.width; x+= incrementX)
        {
            for(int y = startY; y >= 0 && y < grid.height; y += incrementY)
            {
                TileCell cell = grid.GetCell(x, y);
                if (cell.occupied)
                {
                    MoveTile(cell.tile, direction);
                }
            }
        }
    }
    private void MoveTile(MiniGameTile tile, Vector2Int direction)
    {
        TileCell newCell = null;
        TileCell adjacent = grid.GetAdjacentCell(tile.cell, direction);
        while(adjacent != null)
        {
            if (adjacent.occupied)
            {
                //merge
                break;
            }
            newCell = adjacent;
            adjacent = grid.GetAdjacentCell(adjacent, direction);
        }

        if (newCell != null)
        {
            tile.MoveTo(newCell);
        }
    }
}
