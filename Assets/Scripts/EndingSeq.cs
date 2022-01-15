using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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
    public AudioSource scaryEnd;
    public AudioClip popUpEffect;
    AudioSource Audios;
    bool popUpCrash = false;
    int i = 0;

    private void Start()
    {
        Audios = GetComponent<AudioSource>();
    }
    private void Update()
    { 
        Timer += Time.deltaTime;
        if (Timer >= 5 && !HealthStats)
        {
            HealthStats = true;
            cam.SetTrigger("Glitch");
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
    }

    public void CantCatchMe()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("", "Can't Catch me", gameObject, "RemoveVirus", "", "RemoveVirus", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false; 
        multi.popupVariables.spazWindow = false;
        Audios.PlayOneShot(popUpEffect);
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
        }
        else
        {
            VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("...", "I heard that " + country.city + " Was good this time of year", gameObject, "LastOne", "", "LastOne", "");
            VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
            multi.popupVariables.runFromCursor = true;
            multi.popupVariables.closeButton = false;
            Audios.PlayOneShot(popUpEffect);
        }
    }
    public void LastOne()
    {
        if (string.IsNullOrWhiteSpace(country.ip))
        {
            VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("ERROR", "SYSTEM ERROR: VIRUS TAKING OVER. ABORT?", gameObject, "TooLate", "", "Kill", "");
            VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
            multi.popupVariables.runFromCursor = true;
            multi.popupVariables.closeButton = false;
            Audios.PlayOneShot(popUpEffect);
        }
        else
        {
            VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables(country.ip, "SYSTEM ERROR: VIRUS TAKING OVER. ABORT?", gameObject, "TooLate", "", "Kill", "");
            VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
            multi.popupVariables.runFromCursor = true;
            multi.popupVariables.closeButton = false;
            Audios.PlayOneShot(popUpEffect);
        }
    }

    public void TooLate()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("TOO LATE", "YOU CAN'T ABORT ME. I'VE COME TOO FAR! *SYSTEM ERROR* ABORT?", gameObject, "Kill", "", "Kill", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
        Audios.PlayOneShot(popUpEffect);
    }
    public void Kill()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("I'VE WON", "STOP FIGHTING. I HAVE WON! *SYSTEM ERROR: SHUTTING DOWN* BYE BYE HAHAHA", gameObject, "PopupCrash", "0", "PopupCrash", "0");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
        Audios.PlayOneShot(popUpEffect);
    }

    public void PopupCrash()
    {
        popUpCrash = true;
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("HAHAHAHA", "HAHAHAHAHAHAHAHAHA", gameObject, "", "", "", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
        Audios.PlayOneShot(popUpEffect, 0.2f);
        if(i > 19)
        {
            CancelWindow();
            popUpCrash = false;
            KillSwitch();
        }
    }
    public void KillSwitch()
    {
        background.Stop();
        //scaryEnd.Stop(); 
        VideoPlayer.SetActive(true);
        vp.Play();

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
