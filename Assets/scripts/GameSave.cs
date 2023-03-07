using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

//Basado en codigo mostrado en https://www.youtube.com/watch?v=uD7y4T4PVk0
[Serializable]
public class GameSave : MonoBehaviour, ISaveable<GameSave>, ILoadable<GameSave>
{
    //statics are save values, nonstatics are cached values, to update save values you need to SaveAllValues() or modify a static value and then SaveRemotely/RemoteSave
    public static int _Level;
    public static int gems { get => GemManager._Gems; set => GemManager._Gems = value; }
    public static bool _seenTutorial;
    public bool seenTutorial;
    public static string _UserName;
    public int Level;
    public  string UserName;
    public static string _fileName = "SaveDAT";
    public string fileName = "SaveDAT";
    private static string _fullPath;
    public static float _volume;
    public float volume;
    public static bool _bonusReward;
    public bool bonusReward;
    public static GameSave _gameSave;
    public static bool _increasedGemChance;
    public bool increaseGemChance;

    private void Awake()
    {
        if (!_gameSave)
        {
            _gameSave = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _gameSave = this;
        GameManager.Subscribe("UpdateWithSaveValues", UpdateWithSaveValues);
        GameManager.Subscribe("UpdateEditorValues", UpdateEditorValues);
        GameManager.Subscribe("SaveRemotely", RemoteSave);
        GameManager.Subscribe("DeleteSave", DeleteSave);
        FileName();
        _fullPath = Path.Combine(Application.dataPath + @"\Save", _fileName + ".dat");
        //print(_fullPath);
        LoadFile(this);
        UpdateWithSaveValues();
        AudioManager.SwitchNoise(GameSave._volume);
    }
    public void LoadFromSaveData(Save a_Save)
    {
        gems = a_Save.gems;
        /*print(Gems);
        print(a_Save.gems);*/
        _Level = a_Save.level;
        _UserName = a_Save.user;
        _seenTutorial = a_Save.seenTutorial;
        _volume = a_Save.volume;
        _bonusReward = a_Save.bonusReward;
        _increasedGemChance = a_Save.increaseGemChance;
        UpdateEditorValues();
    }

    public void PopulateSaveData(Save a_Save)
    {
        a_Save.volume = _volume;
        a_Save.gems = gems;
        a_Save.level = _Level;
        a_Save.user = _UserName;
        a_Save.seenTutorial = _seenTutorial;
        a_Save.bonusReward = _bonusReward;
        a_Save.increaseGemChance = _increasedGemChance;
    }

    public void SaveFile(GameSave testing)
    {
        Save sf = new Save();
        testing.PopulateSaveData(sf);
        
        if(FileManager.WriteToFile(_fileName + ".dat", sf.SaveData()))
        {
            print("Save Successful" + sf.user + sf.gems + sf.level + sf.seenTutorial + sf.volume + sf.bonusReward + sf.increaseGemChance);
        }
    }

    public void LoadFile(GameSave testing)
    {
        if (FileManager.LoadFromFile(_fileName + ".dat", out var json))
        {
            Save sf = new Save();
            sf.LoadData(json);

            testing.LoadFromSaveData(sf);
            print("Load Successful: " + GameSave._UserName + GameSave.gems + GameSave._Level + GameSave._seenTutorial + GameSave._volume + GameSave._bonusReward + GameSave._increasedGemChance);
        }
    }
    public void DeleteSave()
    {
        FileManager.DeleteFile(_fileName + ".dat");
        gems = 0;
        _Level = 0;
        _UserName = string.Empty;
        _seenTutorial = false;
        _volume = 1;
        _bonusReward = false;
        _increasedGemChance = false;
        SaveFile(this);

    }
    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            SaveAllData(this);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            FileName();
            LoadFile(this);
        } 
        #endif
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
        if (Level > 0)
        {
            _Level = Level;
        }
        if(UserName != null)
        {
            _UserName = UserName;
        }
        if (!seenTutorial)
        {
            _seenTutorial = seenTutorial;
        }
        if (volume != 1)
        {
            _volume = volume;
        }
        if (!bonusReward)
        {
            _bonusReward = bonusReward;
        }
        if (!increaseGemChance)
        {
            _increasedGemChance = increaseGemChance;
        }
        FileName();
    }
    private void UpdateEditorValues()
    {
        Level = _Level;
        UserName = _UserName;
        seenTutorial = _seenTutorial;
        volume = _volume;
        bonusReward = _bonusReward;
        increaseGemChance = _increasedGemChance;
    }
    private void FileName()
    {
        _fileName = fileName;
        if (_fileName == string.Empty)
        {
            _fileName = "SaveDAT";
        }
    }
    private void RemoteSave()
    {
        if (GetComponent<GameSave>())
        {
            GameSave._gameSave.FileName();
            _gameSave.SaveFile(_gameSave);
            UpdateEditorValues();
        }
    }
}
