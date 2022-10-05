using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneSwitcher : MonoBehaviour
{
    [HideInInspector]
    public string _goTo;
    [HideInInspector]
    public bool _noButton;
    private static SceneSwitcher sceneSwitcher;
    public static SceneSwitcher Instance (){
        if(!sceneSwitcher){
            sceneSwitcher = FindObjectOfType<SceneSwitcher>();
            if(!sceneSwitcher){
                Debug.LogError("No hay sceneSwitcher activo");
            }
        }
        return sceneSwitcher;
    }

    private void Start()
    {
        /*switch (SceneManager.GetActiveScene().name) {
            case "MainMenu":
                if (CheckpointSystem.FindObjectOfType<CheckpointSystem>())
                {
                    CheckpointSystem.Instance().ResetCheckpoint();
                }
                Counter c = FindObjectOfType<Counter>();
                if (c && SceneManager.GetActiveScene().name != "Victory")
                {
                    Destroy(c.gameObject);
                }
                break;
            case "Victory":
                if (CheckpointSystem.FindObjectOfType<CheckpointSystem>())
                {
                    CheckpointSystem.Instance().ResetCheckpoint();
                }
                Counter c2 = FindObjectOfType<Counter>();
                if (c2 && SceneManager.GetActiveScene().name != "Victory")
                {
                    c2.CancelInvoke();
                }
                break;
            case "GameOver":
                Counter c1 = FindObjectOfType<Counter>();
                if (c1 && SceneManager.GetActiveScene().name != "Victory")
                {
                    c1.CancelInvoke();
                }
                break;
            case "City":
                Counter c3 = FindObjectOfType<Counter>();
                if (c3 && SceneManager.GetActiveScene().name != "Victory")
                {
                    c3.InvokeRepeating("AddTime", 1f, 1f);
                }
                break;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(_goTo != null){
            if(_noButton && Input.anyKeyDown){
                
                Load(_goTo);
            }
        }
        else{
            Debug.Log("Missing Destination on EventSystem");
        }
    }
    public void Reload(){
        Scene actual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actual.name);
    }
    public void Load(string destination){
        StartCoroutine(LoadSceneAsync(destination));
    }
    private IEnumerator LoadSceneAsync(string destination){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(destination);

        while(!asyncLoad.isDone){
            yield return null;
        }
    }
    public void CloseGame(){
        Application.Quit();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SceneSwitcher))]
[CanEditMultipleObjects]
public class SceneSwitcher_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        SceneSwitcher sceneSwitcher = (SceneSwitcher)target;

        sceneSwitcher._noButton = EditorGUILayout.Toggle("No Buttons for next Scene?", sceneSwitcher._noButton);
        if(sceneSwitcher._noButton){
            sceneSwitcher._goTo = EditorGUILayout.TextField("Scene Destination", sceneSwitcher._goTo);
        }
    }
}
#endif