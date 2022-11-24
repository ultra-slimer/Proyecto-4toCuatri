using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class StoreObject : MonoBehaviour
{
    public ScreenMessage pressResponseMessage;
    public int price;
    public string objectName;
    private string _title; // title should be = to "name priceG"
    private void Start()
    {
        _title = $@"{objectName} - {price}G";
        GetComponentInChildren<Text>().text = _title;
    }

    public void Press()
    {
        Store.instance.Select(this);
    }
}
