using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public int levelCompletionReward;
    public static GameStateManager gameStateManager;
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
        GameSave._increasedGemChance = false;
        GameManager.Trigger("SaveRemotely");
        sceneLoader.RewardingSwitch("Victory", levelCompletionReward);
    }
}
