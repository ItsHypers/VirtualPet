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
            so.health = 100;
            so.hunger = 100;
            so.happiness = 100;
            so.money = 0;
            so.hat = 0;
            so.face = 0;
            so.leftHand = 0;
            so.rightHand = 0;
            so.rightFoot = 0;
            so.leftFoot = 0;
            so.ballsSpawned = 0;
            Upgrade[] allUpgrades = (Upgrade[])Resources.FindObjectsOfTypeAll(typeof(Upgrade));

            foreach(Upgrade upgrades in allUpgrades)
            {
                upgrades.unlocked = false;
            }
            Debug.Log("Loaded Default Stuff");
            Save(so);
        }
        return so;
    }
}
