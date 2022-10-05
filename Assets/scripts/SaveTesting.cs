using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

//Basado en codigo mostrado en https://www.youtube.com/watch?v=uD7y4T4PVk0
[Serializable]
public class SaveTesting : ISaveable<SaveTesting>, ILoadable<SaveTesting>
{
    public static int _Level;
    public static int _Gems;
    public static string _UserName;
    public int Level;
    public int Gems;
    public  string UserName;
    public static string _fileName = string.Empty;
    public string fileName;
    private static string _fullPath;

    private void Start()
    {
        GameManager.Subscribe("UpdateSaveValues", UpdateSaveValues);
        GameManager.Subscribe("UpdateEditorValues", UpdateEditorValues);
        _fileName = fileName;
        if (_fileName == string.Empty)
        {
            _fileName = "SaveDAT";
        }
        _fullPath = Path.Combine(Application.dataPath + @"\Save", _fileName + ".dat");
        //print(_fullPath);
        LoadFile(this);
    }
    public void LoadFromSaveData(Save a_Save)
    {
        _Gems = a_Save.gems;
        _Level = a_Save.level;
        _UserName = a_Save.user;
        GameManager.Trigger("UpdateEditorValues");
    }

    public void PopulateSaveData(Save a_Save)
    {
        a_Save.gems = _Gems;
        a_Save.level = _Level;
        a_Save.user = _UserName;
    }

    public void SaveFile(SaveTesting testing)
    {
        Save sf = new Save();
        testing.PopulateSaveData(sf);
        
        if(FileManager.WriteToFile(_fileName + ".dat", sf.SaveData()))
        {
            //print("Save Successful" + sf.user + sf.gems + sf.level);
        }
    }

    public void LoadFile(SaveTesting testing)
    {
        if (FileManager.LoadFromFile(_fileName + ".dat", out var json))
        {
            Save sf = new Save();
            sf.LoadData(json);

            testing.LoadFromSaveData(sf);
            //print("Load Successful: " + SaveTesting._UserName + SaveTesting._Gems + SaveTesting._Level);
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
        GameManager.Trigger("UpdateSaveValues");
    }

    private void UpdateSaveValues()
    {
        _Gems = Gems;
        _Level = Level;
        _UserName = UserName;
    }
    private void UpdateEditorValues()
    {
        Gems = _Gems;
        Level = _Level;
        UserName = _UserName;
    }
}
