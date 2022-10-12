using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            SceneLoader.sceneLoader.AsyncLoadScene("MainMenu");
        }

    }
}
