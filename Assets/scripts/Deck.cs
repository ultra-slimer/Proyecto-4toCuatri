using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<Cards> _numberOfCards;
    public int CardToUse = 0;
    
   

    [SerializeField] GameObject _mazo;
    [SerializeField] GameObject _prefabCard;

    void Start()
    {
        
        for (int i = 0; i < _numberOfCards.Count; i++)
        {
            GameObject go = Instantiate(_prefabCard) as GameObject;
            go.transform.SetParent(_mazo.transform);
            go.transform.position = Vector3.zero;
            go.transform.localScale = Vector3.one;

            Image img = go.GetComponent<Image>();
            img.sprite = _numberOfCards[i].AssignedCard;

            Button bot = go.GetComponent<Button>();
            bot.onClick.RemoveAllListeners();
            int u = i;
            bot.onClick.AddListener(() => { CardToUse = u; });
        }
    }

}
