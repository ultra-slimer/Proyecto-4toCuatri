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
    public int gems { get => Gems._Gems; set => Gems._Gems = value; }
    public static string _UserName;
    public int Level;
    public  string UserName;
    public static string _fileName = "SaveDAT";
    public string fileName = "SaveDAT";
    private static string _fullPath;
    private static GameSave _gameSave;

    private void Start()
    {
        _gameSave = this;
        GameManager.Subscribe("UpdateWithSaveValues", UpdateWithSaveValues);
        GameManager.Subscribe("UpdateEditorValues", UpdateEditorValues);
        GameManager.Subscribe("SaveRemotely", RemoteSave);
        FileName();
        _fullPath = Path.Combine(Application.dataPath + @"\Save", _fileName + ".dat");
        //print(_fullPath);
        LoadFile(this);
        UpdateWithSaveValues();
    }
    public void LoadFromSaveData(Save a_Save)
    {
        gems = a_Save.gems;
        /*print(Gems);
        print(a_Save.gems);*/
        _Level = a_Save.level;
        _UserName = a_Save.user;
        UpdateEditorValues();
    }

    public void PopulateSaveData(Save a_Save)
    {
        a_Save.gems = gems;
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
            print("Load Successful: " + GameSave._UserName + testing.gems + GameSave._Level);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            SaveAllData(this);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            FileName();
            LoadFile(this);
        }
    }
    public static void SaveAllData(GameSave gameSave)
    {
        gameSave.FileName();
        gameSave.UpdateWithSaveValues();
        gameSave.SaveFile(gameSave);
    }
    private void OnValidate()
    {
        //GameManager.Trigger("UpdateWithSaveValues");
    }

    private void UpdateWithSaveValues()
    {
        _Level = Level;
        _UserName = UserName;
        FileName();
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
    private static void RemoteSave()
    {
        GameSave._gameSave.FileName();
        _gameSave.SaveFile(_gameSave);
    }
}
