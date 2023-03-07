using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostingEnemy : EnemyFather, ISpawnable<BoostingEnemy>, IAttacher<EnemyFather>
{
    public BoxCollider boosteeDetector;
    public EnemyFather boostee;
    public Tile tile;
    public float distanceAboveFinalPosition;
    private static List<BoostingEnemy> boostingEnemies;

    public void SaveThing(BoostingEnemy newThing)
    {
        self = newThing;
    }

    public override void EnemyAction()
    {
    }

    public override void Start()
    {
        flyweight = FlyweightPointer.BoostEnemy;
        base.Start();
    }

    private IEnumerator position(Vector3 height1, Vector3 height2)
    {
        float elapsed = 0;
        float duration = 1;

        while(elapsed < duration)
        {
            transform.position = Vector3.Lerp(height1, height2, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    public override void OnEnable()
    {
        base.OnEnable();
        int y = 0, x = 0;
        do
        {
            y = Random.Range(0, Grid.instance.rows.Length);
        } while (Grid.instance.RowHasAvailableTile(y));
        do
        {
            x = Random.Range(0, Grid.instance.rows[y].cells.Length);
        } while (Grid.instance.rows[y].cells[x].occupied);
        var newPosition = Grid.instance.GetTilePosition(new Vector2Int(x, y));
        newPosition.y += distanceAboveFinalPosition;
        transform.position = newPosition;
        StartCoroutine(position(transform.position, new Vector3(transform.position.x, (transform.position.y + 2f) - (distanceAboveFinalPosition), transform.position.z)));
    }

    public void Attach(EnemyFather attachee)
    {
        boostee = attachee;
        boostee.damageMultiplier = damageMultiplier;
        transform.SetParent(boostee.transform, true);
    }

    public void Deattach()
    {
        boostee.damageMultiplier = 1;
        boostee = null;
        MoveVerically(Vector3Int.up);
        transform.SetParent(null, true);
        StartCoroutine(DisableSelf());
    }

    private void MoveVerically(Vector3Int direction)
    {
        StartCoroutine(position(transform.position, new Vector3(transform.position.x, (transform.position.y) + (distanceAboveFinalPosition * direction.y), transform.position.z)));
    }
    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(1);
        _referenceBack.ReturnObject(this);
    }
    public override void Update()
    {
    }
}
