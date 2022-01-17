using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSeq : MonoBehaviour
{
    protected float Timer;
    public Survival surv;
    public Bank bs;
    public CountryScriptable country;
    public bool EndStarted;
    public Animator cam;
    bool HealthStats;
    bool Popups;
    bool Popup1 = true;
    bool windowOpen = false;
    public GameObject VideoPlayer;
    public VideoPlayer vp;
    public AudioSource background;
    public AudioClip scaryEnd;
    public AudioClip popUpEffect;
    AudioSource Audios;
    public GameObject shop;
    bool popUpCrash = false;
    public bool StreamerMode;
    int i = 0;
    public GameObject laughing;
    AudioSource laugh;
    public GameObject settings;
    public PauseMenu pm;
    private void Start()
    {
        Audios = GetComponent<AudioSource>();
        StreamerMode = PlayerPrefs.GetInt("StreamerMode", 0) != 0;
    }
    private void Update()
    {
        if (EndStarted)
        {
            Timer += Time.deltaTime;
            if (Timer >= 5 && !HealthStats)
            {
                HealthStats = true;
                cam.SetTrigger("Glitch");
                background.clip = scaryEnd;
                background.Play();
                background.volume = 0.3f;
                shop.SetActive(false);
                settings.SetActive(false);
                pm.CloseTabs();
            }
            if (HealthStats && Timer >= 7)
            {
                surv.paused = true;
                surv.Happiness = Random.Range(1, 999);
                surv.Hunger = Random.Range(1, 999);
                surv.Health = Random.Range(1, 999);
                bs.Money = Random.Range(1, 999999);
            }

            if (Timer >= 10 && !Popups)
            {
                Popups = true;
                cam.SetTrigger("Glitch");
            }

            if (Popups && Timer >= 12 && Popup1)
            {
                PopupsStart();
                Popups = false;
                Popup1 = false;
            }
            if (popUpCrash)
            {
                if (i < 20)
                {
                    i++;
                    PopupCrash();
                }

            }
        }
    }
    public void EndGameStart()
    {
        Timer = 0;
        EndStarted = true;
    }

    public void PopupsStart()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("Manual Over-ride Request", "Manual Over-ride Request receive, Scan threat?", gameObject, "WindowSpam", "", "WindowWarning", "");
        VirusGUI.PopupWindow window = new VirusGUI.PopupWindow(vars, new Vector2(Screen.width * .5f - 125, Screen.height * .5f - 75));
        window.popupVariables.closeButton = false;
        Audios.PlayOneShot(popUpEffect);
        cam.SetTrigger("Glitch");
    }
    public void WindowWarning()
    {
        //Opens 3 windows that are the same
        //If you press Yes, it calls the OpenDoor function
        //If you press No, it calls the CancelWindow function
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("Scan Not Initiated", "WARNING, VIRUS DETECTED. IMMEDIATE ATTENTION NEEDED. SCAN DEVICE?", gameObject, "WindowSpam", "", "WindowSpam", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
        Audios.PlayOneShot(popUpEffect);
        cam.SetTrigger("Glitch");

    }
    public void WindowSpam()
    {
        //Opens 3 windows that are the same
        //If you press Yes, it calls the OpenDoor function
        //If you press No, it calls the CancelWindow function
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("Threat Scanned!", "Computer Over-ridden, WARNING; Virus Detected. Attempt Virus Removal?", gameObject, "CantCatchMe", "", "CantCatchMe", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
        Audios.PlayOneShot(popUpEffect);
        cam.SetTrigger("Glitch");

    }

    public void CantCatchMe()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("", "Can't Catch me", gameObject, "RemoveVirus", "", "RemoveVirus", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false; 
        multi.popupVariables.spazWindow = false;
        Audios.PlayOneShot(popUpEffect);
        cam.SetTrigger("Glitch");

    }
    public void RemoveVirus()
    {
        if (string.IsNullOrWhiteSpace(country.city))
        {
            VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("...", "You can't stop me! I'm too Powerful!", gameObject, "LastOne", "", "LastOne", "");
            VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
            multi.popupVariables.runFromCursor = true;
            multi.popupVariables.closeButton = false;
            Audios.PlayOneShot(popUpEffect);
            cam.SetTrigger("Glitch");

        }
        else
        {
            VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("...", "I heard that " + country.city + " Was good this time of year", gameObject, "LastOne", "", "LastOne", "");
            VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
            multi.popupVariables.runFromCursor = true;
            multi.popupVariables.closeButton = false;
            Audios.PlayOneShot(popUpEffect);
            cam.SetTrigger("Glitch");

        }
    }
    public void LastOne()
    {
        if (string.IsNullOrWhiteSpace(country.ip) || StreamerMode)
        {
            VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("ERROR", "SYSTEM ERROR: VIRUS TAKING OVER. ABORT?", gameObject, "TooLate", "", "Kill", "");
            VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
            multi.popupVariables.runFromCursor = true;
            multi.popupVariables.closeButton = false;
            Audios.PlayOneShot(popUpEffect);
            cam.SetTrigger("Glitch");

        }
        else
        {
            VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables(country.ip, "SYSTEM ERROR: VIRUS TAKING OVER. ABORT?", gameObject, "TooLate", "", "Kill", "");
            VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
            multi.popupVariables.runFromCursor = true;
            multi.popupVariables.closeButton = false;
            Audios.PlayOneShot(popUpEffect);
            cam.SetTrigger("Glitch");

        }
    }

    public void TooLate()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("TOO LATE", "YOU CAN'T ABORT ME. I'VE COME TOO FAR! *SYSTEM ERROR* ABORT?", gameObject, "Kill", "", "Kill", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
        Audios.PlayOneShot(popUpEffect);
        cam.SetTrigger("Glitch");

    }
    public void Kill()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("I'VE WON", "STOP FIGHTING. I HAVE WON! *SYSTEM ERROR: SHUTTING DOWN* BYE BYE HAHAHA", gameObject, "PopupCrash", "0", "PopupCrash", "0");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
        Audios.PlayOneShot(popUpEffect);
        cam.SetTrigger("Glitch");

    }

    public void PopupCrash()
    {
        if (i > 19)
        {
            CancelWindow();
            popUpCrash = false;
            KillSwitch();
        }
        else
        {
            popUpCrash = true;
            VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("HAHAHAHA", "HAHAHAHAHAHAHAHAHA", gameObject, "", "", "", "");
            VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
            multi.popupVariables.closeButton = false;
            Audios.PlayOneShot(popUpEffect, 0.3f);
            cam.SetTrigger("Glitch");

        }
    }
    public void KillSwitch()
    {
        background.Stop();
        //scaryEnd.Stop(); 
        VideoPlayer.SetActive(true);
        vp.Play();
        StartCoroutine(Laughing());

    }
    IEnumerator Laughing()
    {
        yield return new WaitForSeconds(6);
        laughing.SetActive(true);
        Image image = laughing.GetComponent<Image>();
        LeanTween.alpha(image.rectTransform, 1f, 7f).setEase(LeanTweenType.linear);
        laugh = laughing.GetComponent<AudioSource>();
        laugh.Play();
        yield return new WaitForSeconds(7.5f);
        laughing.SetActive(false);
        laugh.Stop();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    public void CancelWindow()
    {
        windowOpen = false;
        VirusGUI.virus.RemovePopupsWithFunctionObject(gameObject);
    }

    void OnPopupX()
    {
        CancelWindow();
    }
}
