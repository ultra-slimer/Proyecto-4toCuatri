using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public int levelCompletionReward;
    public static GameStateManager gameStateManager;
    public int levelNumber;
    private void Start()
    {
        gameStateManager = this;
        if(sceneLoader == null)
        {
            sceneLoader = SceneLoader.Instance();
        }
    }

    public void LostGame()
    {
        GameSave._increasedGemChance = false;
        GameManager.Trigger("SaveRemotely");
        sceneLoader.AsyncLoadScene("GameOver");
    }
    public void WonGame()
    {
        StartCoroutine(VicotryProcess());
    }

    private IEnumerator VicotryProcess()
    {
        Time.timeScale = 0.0001f;
        yield return new WaitForSecondsRealtime(3);
        GameSave._increasedGemChance = false;
        if (GameSave._Level < levelNumber)
        {
            GameSave._Level = levelNumber;
        }
        GameManager.Trigger("SaveRemotely");
        sceneLoader.RewardingSwitch("Victory", levelCompletionReward);
    }
}
