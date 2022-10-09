using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ITouchable
{
    private Renderer renderery;
    public int materialID;
    public void Touched(RaycastHit hit)
    {
        renderery = gameObject.GetComponent<Renderer>();
        Transform t = hit.collider.transform;
        Control control = FindObjectOfType<Control>();
        if (t.childCount == 0 && control.U._money >= control.D._numberOfCards[control.D.CardToUse]._Cost)
        {
            GameObject g = Instantiate(control.D._numberOfCards[control.D.CardToUse].gameObject, t.position, Quaternion.Euler(0, 90, 0)) as GameObject;
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
            renderery.material = GetComponentInParent<Grid>().materials[1];
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Cuadricula");
            renderery.material = GetComponentInParent<Grid>().materials[materialID];
        }
    }
}
