using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameSave._seenTutorial = true;
        GameManager.Trigger("SaveRemotely");
    }

}
