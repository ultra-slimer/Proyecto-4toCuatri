using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

//Basado en codigo mostrado en https://www.youtube.com/watch?v=uD7y4T4PVk0
[Serializable]
public class SaveTesting : MonoBehaviour, ISaveable
{
    public int Level;
    public int Coins;
    public string UserName;
    private static string _fileName = string.Empty;
    public string fileName;
    private static string _fullPath;

    private void Start()
    {
        _fileName = fileName;
        if (_fileName == string.Empty)
        {
            _fileName = "SaveDAT";
        }
        _fullPath = Path.Combine(Application.dataPath + @"\Save", _fileName + ".dat");
        print(_fullPath);
        LoadFile(this);
    }
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
        
        if(FileManager.WriteToFile(_fileName + ".dat", sf.SaveData()))
        {
            print("Save Successful" + sf.user + sf.coins + sf.level);
        }
    }

    public static void LoadFile(SaveTesting testing)
    {
        if (FileManager.LoadFromFile(_fileName + ".dat", out var json))
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
            _fileName = fileName;
            SaveFile(this);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            _fileName = fileName;
            LoadFile(this);
        }
    }
}
