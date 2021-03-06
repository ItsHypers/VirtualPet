using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System;
using UnityEngine.EventSystems;
using System.Linq;

public class MainMenuScript : MonoBehaviour
{
    public static string directory = "/SaveData/";
    public static string fileName = "SavedData.json";
    public SaveObject so;
    public GameObject ngWarning;
    public AudioSource error;
    public AudioMixer master;
    public AudioMixer sfx;
    public TMP_Dropdown resolutiondropdown;
    public GameObject Settings;
    public GameObject Credits;
    private int StringtoInt;
    private bool inInput;
    private bool inMenu;
    Resolution[] resolutions;

    public TMP_InputField saveInterval;
    public Toggle saveToggle;
    public Toggle fullscreen;
    public Toggle streamerMode;

    public GameObject[] nonWebGL;

    public GameObject image;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutiondropdown.ClearOptions();
        int currentresolutionindex = 0;
        List<string> options = new List<string>();
        for (int i = resolutions.Length - 1; i >= 0; i--)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " x " + resolutions[i].refreshRate;
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                currentresolutionindex = i;
        }
        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currentresolutionindex;
        resolutions = resolutions.OrderByDescending(res => res.width).ToArray();
        resolutiondropdown.RefreshShownValue();

        saveInterval.text = PlayerPrefs.GetInt("autoSaveTimer", 10).ToString();
        saveToggle.isOn = PlayerPrefs.GetInt("AutoSave", 1) != 0;
        fullscreen.isOn = PlayerPrefs.GetInt("fullscreen", 1) != 0;
        streamerMode.isOn = PlayerPrefs.GetInt("StreamerMode", 1) != 0;

        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            Debug.Log("mac");
            image.GetComponent<RectTransform>().SetTop(-0.0049505f);
            image.GetComponent<RectTransform>().SetBottom(1134.8f);
        }
        else
        {
            Debug.Log("Windows");
            image.GetComponent<RectTransform>().SetTop(0.2077026f);
            image.GetComponent<RectTransform>().SetBottom(0.1923218f);
        }

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            foreach (GameObject go in nonWebGL)
            {
                go.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (inInput)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }

        if(inMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenSettings(false);
                OpenCredits(false);
            }
        }
    }
    public void AutoSave(bool save)
    {
        if (save)
        {
            var i = Convert.ToInt32(save);
            PlayerPrefs.SetInt("AutoSave", i);
        }
        else
        {
            var i = Convert.ToInt32(save);
            PlayerPrefs.SetInt("AutoSave", i);
        }
    }
    public void SaveIntevalChange(string timer)
    {
        StringtoInt = int.Parse(timer);
        if (StringtoInt == 0)
        {
            StringtoInt = 1;
        }
        PlayerPrefs.SetInt("autoSaveTimer", StringtoInt);
    }
    public void IsInInput(bool IsIn)
    {
        if (IsIn)
        {
            inInput = false;
        }
        else
        {
            inInput = true;
        }
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
    public void LoadNewGame(bool answer)
    {
        if (answer)
        {
            string fullPath = Application.persistentDataPath + directory + fileName;
            if (File.Exists(fullPath))
            {

                File.Delete(fullPath);
                PlayerPrefs.SetInt("StartScreen", 1);
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            LeanTween.scale(ngWarning, new Vector3(0, 0, 0), 0.3f);
        }
    }

    public void OpenSettings(bool open)
    {
        if (open)
        {
            LeanTween.scale(Settings, new Vector3(1, 1, 1), 0.7f).setEaseOutBounce();
            inMenu = true;
        }
        else
        {
            LeanTween.scale(Settings, new Vector3(0, 0, 0), 0.7f).setEaseInBounce();
            inMenu = false;
        }
    }

    public void OpenCredits(bool open)
    {
        if (open)
        {
            LeanTween.scale(Credits, new Vector3(1, 1, 1), 0.7f).setEaseOutBounce();
            inMenu = true;
        }
        else
        {
            LeanTween.scale(Credits, new Vector3(0, 0, 0), 0.7f).setEaseInBounce();
            inMenu = false;
        }
    }

    public void Exit()
    {
        Application.Quit();
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

    public void CreditButton(string link)
    {
        Application.OpenURL(link);
    }

}
