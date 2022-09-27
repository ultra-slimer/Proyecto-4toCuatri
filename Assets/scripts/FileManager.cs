using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;


//Hecho por Bronson Zgeb https://github.com/UnityTechnologies/UniteNow20-Persistent-Data
public static class FileManager
{
    public static bool WriteToFile(string a_FileName, string a_FileContents)
    {
        var fullPath = Path.Combine(Application.dataPath + @"\Save", a_FileName);

        try
        {
            File.WriteAllText(fullPath, a_FileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
            return false;
        }
    }

    public static bool LoadFromFile(string a_FileName, out string result)
    {
        var fullPath = Path.Combine(Application.dataPath + @"\Save", a_FileName);

        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            Debug.Log($"Failed to read from {fullPath} with exception {e}");
            result = "";
            return false;
        }
    }
}
