using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class Save
{
    public int coins;
    public int level;
    public string user;

    /*public void UpdateProgress(int newCoins, int newLevel)
    {
        guardado.coins = newCoins;
        guardado.level = newLevel;
    }*/

    /*public void UpdateUserName(string newUser)
    {
        guardado.user = newUser;
    }*/

    public string SaveData()
    {
        return SaveJSON(this);
    }
    private string SaveJSON(Save save)
    {
        string json = JsonUtility.ToJson(this);
        return json;
    }

    public void LoadData(string newJson)
    {
        LoadFromJSON(newJson);
    }
    private void LoadFromJSON(string newJason)
    {
        JsonUtility.FromJsonOverwrite(newJason, this);
    }
}
public interface ISaveable {
    void PopulateSaveData(Save a_Save);
    void LoadFromSaveData(Save a_Save);
}