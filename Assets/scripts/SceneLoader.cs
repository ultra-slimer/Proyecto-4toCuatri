using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] CanvasGroup loadScreen = null;
    [SerializeField] Image loadBar = null;

    public void AsyncLoadScene(string level)
    {
        if(level == "Controls" && GameSave._seenTutorial)
        {
            level = "Game";
        }
        var async = SceneManager.LoadSceneAsync(level);
        //var async = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        //SceneManager.UnloadSceneAsync(0);

        StartCoroutine(WaitToLoadScene(async));
    }

    IEnumerator WaitToLoadScene(AsyncOperation async)
    {
        async.allowSceneActivation = false;
        int frames = 0;
        loadScreen.alpha = 1;

        while (async.progress < 0.89)
        {
            loadBar.fillAmount = async.progress;
            frames += 1;
            Debug.Log(async.progress);
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Tard� " + frames + " frames");
        while (frames < 500)
        {
            frames += 1;
            loadBar.fillAmount = async.progress;
            yield return new WaitForEndOfFrame();
        }

        loadScreen.alpha = 0;
        async.allowSceneActivation = true;
    }
}
