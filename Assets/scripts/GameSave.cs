using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

//Basado en codigo mostrado en https://www.youtube.com/watch?v=uD7y4T4PVk0
[Serializable]
public class GameSave : MonoBehaviour, ISaveable<GameSave>, ILoadable<GameSave>
{
    public static int _Level;
    public int Gems { get => global::Gems._Gems; set => global::Gems._Gems = value; }
    public static string _UserName;
    public int Level;
    public  string UserName;
    public static string _fileName = "SaveDAT";
    public string fileName;
    private static string _fullPath;
    private static GameSave _saveTesting;

    private void Start()
    {
        _saveTesting = this;
        GameManager.Subscribe("UpdateWithSaveValues", UpdateWithSaveValues);
        GameManager.Subscribe("UpdateEditorValues", UpdateEditorValues);
        GameManager.Subscribe("SaveRemotely", RemoteSave);
        FileName();
        _fullPath = Path.Combine(Application.dataPath + @"\Save", _fileName + ".dat");
        //print(_fullPath);
        LoadFile(this);
        GameManager.Trigger("UpdateWithSaveValues");
    }
    public void LoadFromSaveData(Save a_Save)
    {
        Gems = a_Save.gems;
        /*print(Gems);
        print(a_Save.gems);*/
        _Level = a_Save.level;
        _UserName = a_Save.user;
        GameManager.Trigger("UpdateEditorValues");
    }

    public void PopulateSaveData(Save a_Save)
    {
        a_Save.gems = Gems;
        a_Save.level = _Level;
        a_Save.user = _UserName;
    }

    public void SaveFile(GameSave testing)
    {
        Save sf = new Save();
        testing.PopulateSaveData(sf);
        
        if(FileManager.WriteToFile(_fileName + ".dat", sf.SaveData()))
        {
            print("Save Successful" + sf.user + sf.gems + sf.level);
        }
    }

    public void LoadFile(GameSave testing)
    {
        if (FileManager.LoadFromFile(_fileName + ".dat", out var json))
        {
            Save sf = new Save();
            sf.LoadData(json);

            testing.LoadFromSaveData(sf);
            print("Load Successful: " + GameSave._UserName + testing.Gems + GameSave._Level);
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
    private void OnValidate()
    {
        //GameManager.Trigger("UpdateWithSaveValues");
    }

    private void UpdateWithSaveValues()
    {
        _Level = Level;
        _UserName = UserName;
        _fileName = fileName;
    }
    private void UpdateEditorValues()
    {
        Level = _Level;
        UserName = _UserName;
    }
    private void FileName()
    {
        _fileName = fileName;
        if (_fileName == string.Empty)
        {
            _fileName = "SaveDAT";
        }
    }
    public void LoadStart()
    {
    }
    private static void RemoteSave()
    {
        _saveTesting.SaveFile(_saveTesting);
    }
}
