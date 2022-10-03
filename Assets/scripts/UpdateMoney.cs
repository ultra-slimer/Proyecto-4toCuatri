using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour
{
    [SerializeField]
    Text TextMoney;



    public int _money;

    void Start()
    {
        ActMoney(300);
    }

    public void ActMoney(int Add)
    {
        Debug.Log("pipo");
        _money += Add;
        TextMoney.text = _money.ToString();
    }

}
