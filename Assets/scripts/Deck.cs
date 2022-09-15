using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<Cards> _numberOfCards;

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
        }
    }

}
