using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPerSecond : MonoBehaviour
{
    public bool earning;
    public int money;
    

    [SerializeField]
    int _frequencyMoney;



   IEnumerator Start()
   {
        while (earning)
        {
            yield return new WaitForSeconds(_frequencyMoney);
            UpdateMoney.updatemoney.ActMoney(money);
        }
   }
}
