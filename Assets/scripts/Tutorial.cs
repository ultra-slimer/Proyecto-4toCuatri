using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Button startGame;
    // Start is called before the first frame update
    void Start()
    {
        if (GameSave._seenTutorial){
            startGame.gameObject.SetActive(false);
        }
    }
    public void seenTutorial()
    {
        GameSave._seenTutorial = true;
        GameManager.Trigger("SaveRemotely");
    }
}
