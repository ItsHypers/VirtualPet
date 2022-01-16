using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System;

public class MainMenuScript : MonoBehaviour
{
    public static string directory = "/SaveData/";
    public static string fileName = "SavedData.json";
    public SaveObject so;
    public GameObject ngWarning;
    public AudioSource error;
    public AudioMixer master;
    public AudioMixer sfx;
    public TMP_Dropdown dropdown;
    public GameObject Settings;

    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;
        dropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        dropdown.AddOptions(options);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    public void StreamerMode(bool on)
    {
        var i = Convert.ToInt32(on);
        PlayerPrefs.SetInt("StreamerMode", i);
    }
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
        LeanTween.scale(ngWarning, new Vector3(1, 1, 1), 0.3f);
        error.Play();
    }
    public void OpenSettings(bool open)
    {
        if(open)
            LeanTween.scale(Settings, new Vector3(1, 1, 1), 0.3f);
        else
            LeanTween.scale(Settings, new Vector3(0, 0, 0), 0.3f);
    }

    public void Exit()
    {
        Application.Quit();
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
            LeanTween.scale(ngWarning, new Vector3(0, 0, 0), 0.3f);
        }
    }

    public void SetMasterVolume(float volume)
    {
        master.SetFloat("master", volume);
    }
    public void SetSFXVolume(float volume)
    {
        sfx.SetFloat("sfx", volume);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
