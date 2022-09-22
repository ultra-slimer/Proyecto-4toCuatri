using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


[Serializable]
public class SaveTesting : MonoBehaviour, ISaveable
{
    public int Level;
    public int Coins;
    public string UserName;
    public void LoadFromSaveData(Save a_Save)
    {
        Coins = a_Save.coins;
        Level = a_Save.level;
        UserName = a_Save.user;
    }

    public void PopulateSaveData(Save a_Save)
    {
        a_Save.coins = Coins;
        a_Save.level = Level;
        a_Save.user = UserName;
    }

    public static void SaveFile(SaveTesting testing)
    {
        Save sf = new Save();
        testing.PopulateSaveData(sf);
        
        if(FileManager.WriteToFile("SaveDAT.dat", sf.SaveData()))
        {
            print("Save Successful" + sf.user + sf.coins + sf.level);
        }
    }

    public static void LoadFile(SaveTesting testing)
    {
        if (FileManager.LoadFromFile("SaveDAT.dat", out var json))
        {
            Save sf = new Save();
            sf.LoadData(json);

            testing.LoadFromSaveData(sf);
            print("Load Successful: " + testing.UserName + testing.Coins + testing.Level);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            SaveFile(this);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            LoadFile(this);
        }
    }
}
