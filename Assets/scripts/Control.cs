using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    //RaycastHit hit;
    [SerializeField] Deck D;
    int _layerMask;
    public void Start()
    {
        _layerMask = LayerMask.GetMask("Cuadricula");
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

            Debug.Log("fun");

            Transform t = hit.collider.transform;
            if (t.childCount == 0)
            {
                GameObject g = Instantiate(D._numberOfCards[0].gameObject, t.position, gameObject.transform.rotation = Quaternion.Euler(0,90,0)) as GameObject;
                g.transform.SetParent(t);
            }
        }
    }
}
