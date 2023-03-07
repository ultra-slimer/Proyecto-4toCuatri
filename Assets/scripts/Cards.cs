using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour, IDamageable<float>, IKillable, IObstacle
{
    [SerializeField]
    public float _Health;
    [SerializeField]
    float _MaxHealth;
    [SerializeField]
    public float damage;
    public int _Cost;   
    public Sprite AssignedCard;
    [SerializeField]
    int _gift;
    public Tile tile;

    public ParticleSystem DeathPartycle;

    

    private void Awake()
    {
        //gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    private void Start()
    {
        _Health = _MaxHealth;
        _gift = _Cost / 10;
        Debug.Log(_Health);
        DeathPartycle.Pause();
    }
    virtual public void Shoot()
    {

    }

    

    public virtual void Damage(float damageTaken, float multiplier = 1)
    {
        Debug.Log(_Health);
        _Health -= damageTaken;
       
        if (_Health <= 0)
        {        
            Death();
        }
    }

    public void Death()
    {       
        UpdateMoney.updatemoney.ActMoney(_gift);
        tile.EvictOccupant();
        StartCoroutine(ReEnableCooldown());
    }

    private IEnumerator ReEnableCooldown()
    {
        MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        Light[] light = gameObject.GetComponentsInChildren<Light>();
        DeathPartycle.Play();
        foreach (var a in light)
        {
            Destroy(a);
        }
        foreach(var a in meshRenderers)
        {
            Destroy(a);
        }
       

        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
        yield return new WaitForSeconds(5);
        GetComponentInParent<Tile>()?.CanInteractToggle();
        //DeathPartycle.Play();
        Destroy(gameObject);
    }

    void aaaaaa()
    {
        if (Grid.instance.RowHasAvailableTile(tile.coordinates.y)) {
            int x;
            do
            {
                x = Random.Range(0, Grid.instance.rows.Length - 1);
            } while (Grid.instance.GetTile(x, tile.coordinates.y).occupied);
            var position = Grid.instance.GetTilePosition(new Vector2Int(x, tile.coordinates.y));
            //cambiar valor de Y de position para que este por arriba de la tile y esa es la posicion de inicio del proyectil
        //spawnea proyectil, y se le da las coordenadas Grid.Instance.
        }
    }
   
}
