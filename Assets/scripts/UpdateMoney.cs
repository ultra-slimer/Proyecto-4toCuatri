using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour
{
    [SerializeField]
    Text TextMoney;

    public static UpdateMoney updatemoney;

    public int _money;

    void Start()
    {
        updatemoney = this;
        ActMoney(400);
    }

    public void ActMoney(int Add)
    {
        Debug.Log("pipo");
        _money += Add;
        TextMoney.text = _money.ToString();
    }

}
