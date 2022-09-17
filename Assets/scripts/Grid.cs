using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public void CanInteract(bool isOrNot)
    {
        if (isOrNot)
        {
            gameObject.layer = LayerMask.NameToLayer("Cuadricula");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
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
