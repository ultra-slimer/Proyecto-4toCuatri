using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = SceneLoader.Instance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(GameSave._volume);
        }
    }

    public void LoadScene(string name)
    {
        if (StaminaSystem.HaveStamina == true && name == "Controls" || name != "Controls")
        {
            sceneLoader.AsyncLoadScene(name);
        }
        //sceneLoader.AsyncLoadScene(name);
    }
    public void DeleteSave()
    {
        GameManager.Trigger("DeleteSave");
        GameSave._seenTutorial = false;
        GameSave.gems = 0;
        GameManager.Trigger("SaveRemotely");
    }
}
