using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    //RaycastHit hit;
    [SerializeField] Deck D;
    [SerializeField] UpdateMoney U;
    
    int _layerMask;
    public void Start()
    {
        _layerMask = LayerMask.GetMask("Cuadricula");
        GameManager.Subscribe("SpawnUnit", Touch);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GameManager.Trigger("SpawnUnit");
        
    }

    public void Touch()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, _layerMask))
        {
           
            Transform t = hit.collider.transform;

            if (t.childCount == 0 && U._money >= D._numberOfCards[D.CardToUse]._Cost)
            {
                GameObject g = Instantiate(D._numberOfCards[D.CardToUse].gameObject, t.position, gameObject.transform.rotation = Quaternion.Euler(0, 90, 0)) as GameObject;
                hit.collider.GetComponent<Grid>().CanInteract(false);
                g.transform.SetParent(t);

                Debug.Log("fun2");

                U.ActMoney(-D._numberOfCards[D.CardToUse]._Cost);
            }
            else return;
        }
    }

    
}
