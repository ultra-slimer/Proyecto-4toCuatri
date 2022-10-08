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
        
    }

    public void LoadScene(string name)
    {
        sceneLoader.AsyncLoadScene(name);
    }
    public void DeleteSave()
    {
        GameManager.Trigger("DeleteSave");
    }
}
