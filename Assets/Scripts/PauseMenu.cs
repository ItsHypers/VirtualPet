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
public class PauseMenu : MonoBehaviour
{
    [Header("bools")]
    public bool inShop;

    [Header("Object References")]
    public TMP_InputField saveInterval;
    public TMP_InputField ballInput;
    public GameObject SaveChecker;
    public GameObject Shop;
    public AudioMixer master;
    public AudioMixer sfx;
    public TMP_Dropdown resolutiondropdown;
    public GameObject Settings;
    public GameObject Cheat;
    public Toggle saveToggle;
    public Toggle fullscreen;
    public SaveScript ss;
    public Toggle streamerMode;
    public SuppliesBuyingScript sbs;

    [Header("SO")]
    public SaveObject so;

    Resolution[] resolutions;
    private bool SettingsIsOpen;
    private bool CheatIsOpen;
    private bool inInput;
    private int StringtoInt;
    private int balls;
    private int moneyamount;
    public Bank bs;
    [SerializeField]
    private GameObject playerStat;
    [SerializeField]
    private GameObject settingb;
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private GameObject moneybutton;
    [SerializeField]
    private GameObject shopButton;

    [SerializeField]
    private GameObject camobj;

    public GameObject[] nonWebGL;
    private void Start()
    {
        saveInterval.text = PlayerPrefs.GetInt("autoSaveTimer", 10).ToString();
        ballInput.text = sbs.ballsSpawned.ToString();
        saveToggle.isOn = PlayerPrefs.GetInt("AutoSave", 1) != 0;
        fullscreen.isOn = PlayerPrefs.GetInt("fullscreen", 1) != 0;
        streamerMode.isOn = PlayerPrefs.GetInt("StreamerMode", 1) != 0;
        LeanTween.scale(Shop, new Vector3(0, 0, 0), 0.6f).setOnComplete(setActive);

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

        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            playerStat.GetComponent<RectTransform>().SetTop(-8.369995f);
            playerStat.GetComponent<RectTransform>().SetBottom(-1088.37f);
            playerStat.GetComponent<RectTransform>().SetLeft(-97.441f);
            playerStat.GetComponent<RectTransform>().SetRight(96.559f);


            shop.GetComponent<RectTransform>().SetTop(-20.0995f);
            shop.GetComponent<RectTransform>().SetBottom(31.3045f);
            shop.GetComponent<RectTransform>().SetLeft(79f);
            shop.GetComponent<RectTransform>().SetRight(-37f);

            settingb.GetComponent<RectTransform>().SetBottom(1043.776f);
            settingb.GetComponent<RectTransform>().SetTop(0.009765625f);
            settingb.GetComponent<RectTransform>().SetLeft(1736.833f);

            moneybutton.GetComponent<RectTransform>().SetTop(1001.438f);
            moneybutton.GetComponent<RectTransform>().SetBottom(40.26465f);
            moneybutton.GetComponent<RectTransform>().SetLeft(23.37079f);
            moneybutton.GetComponent<RectTransform>().SetRight(1433.436f);


            shopButton.GetComponent<RectTransform>().SetTop(94.80499f);
            shopButton.GetComponent<RectTransform>().SetBottom(875.765f);
            shopButton.GetComponent<RectTransform>().SetLeft(1653.466f);
            shopButton.GetComponent<RectTransform>().SetRight(0.02001953f);


            camobj.transform.position = new Vector3(30.09f, 12.2f, 0.97f);
        }
        
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            foreach(GameObject go in nonWebGL)
            {
                go.SetActive(false);
            }
        }
        fullscreen.isOn = Screen.fullScreen;
    }

    private void Update()
    {

        if(Input.GetKey(KeyCode.F1) && Input.GetKey(KeyCode.LeftShift) && !CheatIsOpen)
        {
            OpenCheat(true);
        }
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


    public void setBallCount(string toys)
    {
        balls = int.Parse(toys);
        if (balls > 2000)
        {
            balls = 2000;
        }
        sbs.toysSpawned = balls;
        Debug.Log("balls spawned");
        sbs.ManualBallSpawn();
    }
    public void ClearBalls()
    {
        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("ball");
        GameObject[] teddys;
        teddys = GameObject.FindGameObjectsWithTag("teddy");
        GameObject[] gameBoy;
        gameBoy = GameObject.FindGameObjectsWithTag("gameboy");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
        foreach (GameObject teddy in teddys)
        {
            Destroy(teddy);
        }
        foreach (GameObject game in gameBoy)
        {
            Destroy(game);
        }
    }
    public void OpenSettings(bool open)
    {
        if (!SettingsIsOpen)
        {
            Settings.SetActive(true);
            LeanTween.scale(Settings, new Vector3(1, 1, 1), 0.3f);
            SettingsIsOpen = true;
        }
        else
        {
            LeanTween.scale(Settings, new Vector3(0, 0, 0), 0.3f);
            Settings.SetActive(false);
            SettingsIsOpen = false;
        }
    }

    public void OpenCheat(bool open)
    {
        if (!CheatIsOpen)
        {
            Cheat.SetActive(true);
            LeanTween.scale(Cheat, new Vector3(1, 1, 1), 0.3f);
            CheatIsOpen = true;
        }
        else
        {
            LeanTween.scale(Cheat, new Vector3(0, 0, 0), 0.3f);
            Cheat.SetActive(false);
            CheatIsOpen = false;
        }
    }

    public void MainMenu()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            SceneManager.LoadScene(0);
        }
        else
            LeanTween.scale(SaveChecker, new Vector3(1, 1, 1), 0.3f);
    }
    public void SaveCheck(bool save)
    {
        if(save)
        {
            ss.manualSave = true;
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
            LeanTween.scale(Shop, new Vector3(0, 0, 0), 0.8f).setEaseInBounce().setOnComplete(setActive);
        }
        else
        {
            Shop.SetActive(true);
            LeanTween.scale(Shop, new Vector3(1, 1, 0), 0.8f).setEaseOutBounce();
            inShop = true;
        }
    }

    public void CloseTabs()
    {
        LeanTween.scale(Shop, new Vector3(0, 0, 0), 0.3f);
        LeanTween.scale(Settings, new Vector3(0, 0, 0), 0.3f);
    }
    public void setActive()
    {
        if (inShop)
        {
            Shop.SetActive(false);
            inShop = false;
        }
    }

    public void Give10()
    {
        bs.Money = bs.Money + 10000;
    }
    public void setMoneyCount(string money)
    {
        moneyamount = int.Parse(money);
        bs.Money = bs.Money = moneyamount;
    }
}
public static class RectTransformExtensions
{
    public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }


}