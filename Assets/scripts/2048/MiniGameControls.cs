using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControls : SwipeDetection
{
    public TileBoard tileBoard;
    public TileGrid tileGrid;
    public override void OnSwipeDown()
    {
        base.OnSwipeDown();
        tileBoard.MoveTiles(Vector2Int.down, 0, 1, tileGrid.height - 2, -1);
    }
    public override void OnSwipeLeft()
    {
        base.OnSwipeLeft();
        tileBoard.MoveTiles(Vector2Int.left, 1, 1, 0, 1);
    }
    public override void OnSwipeRight()
    {
        base.OnSwipeRight();
        tileBoard.MoveTiles(Vector2Int.right, tileGrid.width - 2, -1, 0, 1);
    }
    public override void OnSwipeUp()
    {
        base.OnSwipeUp();
        tileBoard.MoveTiles(Vector2Int.up, 0, 1, 1, 1);
    }
}
