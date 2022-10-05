using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour
{
    private Button _current;
    private Text _buttonText;
    // Start is called before the first frame update
    void Start()
    {
        _current = this.GetComponentInParent<Button>();
        _buttonText = this.GetComponentInChildren<Text>();
        _buttonText.text = _current.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
