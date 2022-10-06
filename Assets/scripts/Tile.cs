using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ITouchable
{
    public void Touched(RaycastHit hit)
    {
        Transform t = hit.collider.transform;
        Control control = FindObjectOfType<Control>();
        if (t.childCount == 0 && control.U._money >= control.D._numberOfCards[control.D.CardToUse]._Cost)
        {
            GameObject g = Instantiate(control.D._numberOfCards[control.D.CardToUse].gameObject, t) as GameObject;
            g.transform.rotation = Quaternion.Euler(0, 90, 0);
            CanInteractToggle();
            g.transform.SetParent(t);

            //Debug.Log("fun2");

            control.U.ActMoney(-control.D._numberOfCards[control.D.CardToUse]._Cost);
        }
    }

    private void OnMouseEnter()
    {
        gameObject.transform.localScale += new Vector3(0.2f, 0.3f, 0.2f);
        transform.localPosition += new Vector3(0, 0.2f, 0);
    }
    private void OnMouseExit()
    {
        gameObject.transform.localScale -= new Vector3(0.2f, 0.3f, 0.2f);
        transform.localPosition -= new Vector3(0, 0.2f, 0);
    }

    public void CanInteractToggle()
    {
        if (LayerMask.LayerToName(gameObject.layer) == "Cuadricula")
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Cuadricula");
        }
    }
}
