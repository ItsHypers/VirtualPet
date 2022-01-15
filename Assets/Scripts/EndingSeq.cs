using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    public void WindowWarning()
    {
        //Opens 3 windows that are the same
        //If you press Yes, it calls the OpenDoor function
        //If you press No, it calls the CancelWindow function
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("Scan Not Initiated", "WARNING, VIRUS DETECTED. IMMEDIATE ATTENTION NEEDED. SCAN DEVICE?", gameObject, "WindowSpam", "", "WindowSpam", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
    }
    public void WindowSpam()
    {
        //Opens 3 windows that are the same
        //If you press Yes, it calls the OpenDoor function
        //If you press No, it calls the CancelWindow function
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("Threat Scanned!", "Computer Over-ridden, WARNING; Virus Detected. Attempt Virus Removal?", gameObject, "CantCatchMe", "", "CantCatchMe", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
    }

    public void CantCatchMe()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("", "Can't Catch me", gameObject, "RemoveVirus", "", "RemoveVirus", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false; multi.popupVariables.spazWindow = true;
    }
    public void RemoveVirus()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("...", "I heard that " + country.city + " Was good this time of year", gameObject, "LastOne", "", "LastOne", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.runFromCursor = true;
        multi.popupVariables.closeButton = false;
    }
    public void LastOne()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables(country.ip, "SYSTEM ERROR: VIRUS TAKING OVER. ABORT?", gameObject, "TooLate", "", "Kill", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.runFromCursor = true;
        multi.popupVariables.closeButton = false;
    }

    public void TooLate()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("TOO LATE", "YOU CAN'T ABORT ME. I'VE COME TOO FAR! *SYSTEM ERROR* ABORT?", gameObject, "Kill", "", "Kill", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
    }
    public void Kill()
    {
        VirusGUI.PopupVariables vars = new VirusGUI.PopupVariables("I'VE WON", "STOP FIGHTING. I HAVE WON! *SYSTEM ERROR: SHUTTING DOWN* BYE BYE HAHAHA", gameObject, "KillSwitch", "", "KillSwitch", "");
        VirusGUI.MultiWindow multi = new VirusGUI.MultiWindow(1, 5, vars);
        multi.popupVariables.closeButton = false;
    }
    public void KillSwitch()
    {
        Debug.Log("killswitch");
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
