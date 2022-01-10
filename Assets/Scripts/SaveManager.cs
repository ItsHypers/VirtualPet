using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "SavedData.json";

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        //string json = JsonUtility.ToJson(so, true);
        string json = JsonConvert.SerializeObject(so, Formatting.Indented);
        File.WriteAllText(dir + fileName, json);
    }
    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject so = new SaveObject();

        if(File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }
        return so;
    }
}
