using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public string[] touchables =
    {
        "Cuadricula",
        "Gems"
    };
    //RaycastHit hit;
    [SerializeField] Deck D;
    [SerializeField] UpdateMoney U;
    
    int _layerMask;
    public void Start()
    {
        _layerMask = LayerMask.GetMask(touchables);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Touch();
    }

    public void Touch()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, _layerMask))
        {
            TouchActions(hit);
            /*if (t.childCount == 0 && U._money >= D._numberOfCards[D.CardToUse]._Cost)
            {
                GameObject g = Instantiate(D._numberOfCards[D.CardToUse].gameObject, t.position, gameObject.transform.rotation = Quaternion.Euler(0, 90, 0)) as GameObject;
                hit.collider.GetComponent<Tile>()?.CanInteract(false);
                g.transform.SetParent(t);

                //Debug.Log("fun2");

                U.ActMoney(-D._numberOfCards[D.CardToUse]._Cost);
            }
            else return;*/
        }
    }

    private void TouchActions(RaycastHit hit)
    {
        string layerHitName = LayerMask.LayerToName(hit.collider.gameObject.layer);
        switch (layerHitName)
        {
            case "Cuadricula":
                Transform t = hit.collider.transform;
                if (t.childCount == 0 && U._money >= D._numberOfCards[D.CardToUse]._Cost)
                {
                    GameObject g = Instantiate(D._numberOfCards[D.CardToUse].gameObject, t.position, gameObject.transform.rotation = Quaternion.Euler(0, 90, 0)) as GameObject;
                    hit.collider.GetComponent<Tile>()?.CanInteract(false);
                    g.transform.SetParent(t);

                    //Debug.Log("fun2");

                    U.ActMoney(-D._numberOfCards[D.CardToUse]._Cost);
                }
                else return;
                break;
            case "Gems":
                Gems.AddGems();
                GemSpawner.gemSpawner.EndOne(hit.transform.GetComponent<Gems>());
                break;
            default:
                Debug.LogError($"No layer was found that matched with touchActions, layer obtained was {layerHitName}");
                break;
        }
    }
}
