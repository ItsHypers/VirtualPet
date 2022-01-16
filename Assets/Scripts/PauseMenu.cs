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
public class PauseMenu : MonoBehaviour
{
    [Header("bools")]
    public bool inShop;

    [Header("Object References")]
    public TMP_InputField saveInterval;
    public TMP_InputField ballInput;
    public GameObject SaveChecker;
    public GameObject Tabs;
    public GameObject Shop;
    public AudioMixer master;
    public AudioMixer sfx;
    public TMP_Dropdown dropdown;
    public GameObject Settings;
    public Toggle saveToggle;
    public Toggle fullscreen;
    public SaveScript ss;
    public Toggle streamerMode;
    public SuppliesBuyingScript sbs;

    [Header("SO")]
    public SaveObject so;


    Resolution[] resolutions;
    private bool SettingsIsOpen;
    private bool inInput;
    private int StringtoInt;
    private int balls;
    private void Start()
    {
        saveInterval.text = PlayerPrefs.GetInt("autoSaveTimer", 10).ToString();
        ballInput.text = sbs.ballsSpawned.ToString();
        saveToggle.isOn = PlayerPrefs.GetInt("AutoSave", 1) != 0;
        fullscreen.isOn = PlayerPrefs.GetInt("fullscreen", 1) != 0;
        streamerMode.isOn = PlayerPrefs.GetInt("StreamerMode", 1) != 0;
        LeanTween.scale(Tabs, new Vector3(0, 0, 0), 0.6f);
        LeanTween.scale(Shop, new Vector3(0, 0, 0), 0.6f).setOnComplete(setActive);

        resolutions = Screen.resolutions;
        dropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        dropdown.AddOptions(options);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SettingsIsOpen)
                OpenSettings(false);
            else
                OpenSettings(true);
        }
        if (inInput)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    public void ManualSave()
    {
        ss.manualSave = true;
    }

    public void LoadGame()
    {
        ss.LoadGame();
    }

    public void StreamerMode(bool on)
    {
        var i = Convert.ToInt32(on);
        PlayerPrefs.SetInt("StreamerMode", i);
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
        if(StringtoInt == 0)
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


    public void setBallCount(string ball)
    {
        balls = int.Parse(ball);
        if (balls > 2000)
        {
            balls = 2000;
        }
        sbs.ballsSpawned = balls;
        Debug.Log("balls spawned");
        sbs.ManualBallSpawn();
    }
    public void ClearBalls()
    {
        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("ball");
        foreach(GameObject ball in balls)
        {
            Destroy(ball);
        }
    }
    public void OpenSettings(bool open)
    {
        if (!SettingsIsOpen)
        {
            LeanTween.scale(Settings, new Vector3(1, 1, 1), 0.3f);
            SettingsIsOpen = true;
        }
        else
        {
            LeanTween.scale(Settings, new Vector3(0, 0, 0), 0.3f);
            SettingsIsOpen = false;
        }
    }

    public void MainMenu()
    {
        LeanTween.scale(SaveChecker, new Vector3(1, 1, 1), 0.3f);
    }
    public void SaveCheck(bool save)
    {
        if(save)
        {
            SaveManager.Save(so);
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void SaveCancel()
    {
        LeanTween.scale(SaveChecker, new Vector3(0, 0, 0), 0.3f);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
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
        if (isFullScreen)
        {
            var i = Convert.ToInt32(isFullScreen);
            PlayerPrefs.SetInt("fullscreen", i);
        }
        else
        {
            var i = Convert.ToInt32(isFullScreen);
            PlayerPrefs.SetInt("fullscreen", i);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void openShop()
    {
        if (inShop)
        {
            LeanTween.scale(Tabs, new Vector3(0, 0, 0), 0.3f);
            LeanTween.scale(Shop, new Vector3(0, 0, 0), 0.3f).setOnComplete(setActive);
        }
        else
        {
            Tabs.SetActive(true);
            Shop.SetActive(true);
            LeanTween.scale(Tabs, new Vector3(1, 1, 0), 0.3f);
            LeanTween.scale(Shop, new Vector3(1, 1, 0), 0.3f);
            inShop = true;
        }
    }
    public void setActive()
    {
        if (inShop)
        {
            Tabs.SetActive(false);
            Shop.SetActive(false);
            inShop = false;
        }
    }
}