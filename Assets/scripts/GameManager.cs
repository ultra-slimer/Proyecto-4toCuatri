using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text TextMoney;
   
   

    int _money;

    void Start()
    {
        ActMoney(0);   
    }
    
    public void ActMoney(int Add)
    {
        _money += Add;
        TextMoney.text = _money.ToString();
    }

  
}
