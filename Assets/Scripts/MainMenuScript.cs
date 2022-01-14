using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class MainMenuScript : MonoBehaviour
{
    public static string directory = "/SaveData/";
    public static string fileName = "SavedData.json";
    public SaveObject so;
    public GameObject ngWarning;
    public AudioSource error;


    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
    public void NewGame()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        if (File.Exists(fullPath))
        {
            NewGameWarning();
        }
        else
        {
            Debug.Log("file not found");
            SceneManager.LoadScene(1);
        }
    }
    public void NewGameWarning()
    {
        ngWarning.SetActive(true);
        error.Play();
    }

    public void LoadNewGame(bool answer)
    {
        if (answer)
        {
            string fullPath = Application.persistentDataPath + directory + fileName;
            if (File.Exists(fullPath))
            {

                File.Delete(fullPath);
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            ngWarning.SetActive(false);
        }
    }
}
