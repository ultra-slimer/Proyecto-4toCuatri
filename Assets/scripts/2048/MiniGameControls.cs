using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControls : SwipeDetection
{
    public TileBoard tileBoard;
    public TileGrid tileGrid;

    private void Start()
    {
        tileBoard = FindObjectOfType<TileBoard>();
        tileGrid = FindObjectOfType<TileGrid>();
    }
    public override void OnSwipeDown()
    {
        if (!tileBoard.waiting)
        {
            base.OnSwipeDown();
            tileBoard.MoveTiles(Vector2Int.down, 0, 1, tileGrid.height - 2, -1);
        }
    }
    public override void OnSwipeLeft()
    {
        if (!tileBoard.waiting)
        {
            base.OnSwipeLeft();
            tileBoard.MoveTiles(Vector2Int.left, 1, 1, 0, 1);
        }
    }
    public override void OnSwipeRight()
    {
        if (!tileBoard.waiting)
        {
            base.OnSwipeRight();
            tileBoard.MoveTiles(Vector2Int.right, tileGrid.width - 2, -1, 0, 1);
        }
    }
    public override void OnSwipeUp()
    {
        if (!tileBoard.waiting)
        {
            base.OnSwipeUp();
            tileBoard.MoveTiles(Vector2Int.up, 0, 1, 1, 1);
        }
    }
}
