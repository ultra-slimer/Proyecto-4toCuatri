using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ITouchable
{
    public void Touched()
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

}
