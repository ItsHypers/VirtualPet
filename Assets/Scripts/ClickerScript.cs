using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ClickerScript : MonoBehaviour
{

    public Bank bs;
    public int DelayAmount = 1; // Second count
    protected float Timer;
    public float increment;
    public Survival surv;
    public Upgrade[] allUpgrades;
    private int upgradeUnlock;
    public float buttonIncrease;
    public TMP_Text buttonText;
    private float Hi;
    private float FI;
    private float RFI;
    private float LFI;
    private float LGI;
    private float RGI;
    private void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0); 
            increment = 1;
        }
        if(buttonIncrease == 0)
        {
            buttonIncrease = 1;
            UpdateButton(buttonIncrease);
        }
    }
    private void Update()
    {
        if (!surv.paused)
        {
            Timer += Time.deltaTime;
            if (Timer >= DelayAmount)
            {
                Timer = 0f;
                bs.Money = bs.Money + increment;
                bs.increment = increment;
            }
        }
    }

public void UpdateButton(float amount)
    {
        buttonIncrease = amount;
        
        buttonText.text = "Send Email" + "-" + Environment.NewLine + "+ $" + buttonIncrease;
    }

    public void ButtonScript()
    {
        bs.Money = bs.Money + buttonIncrease;
        Debug.Log(buttonIncrease);
    }
    public void Upgrade(float amount, float remove, string item)
    {
        if(item == "upgrade")
        {
            increment = increment - remove;
            increment = increment + amount;
        }
        if (item == "hat")
        {
            if (amount > Hi)
            {
                increment = increment - remove;
                increment = increment + amount;
                Hi = amount;
            }
        }
        if(item == "face")
        {
            if (amount > FI)
            {
                increment = increment - remove;
                increment = increment + amount;
                FI = amount;
            }
        }
        if (item == "LG")
        {
            if (amount > LGI)
            {
                increment = increment - remove;
                increment = increment + amount;
                FI = amount;
            }
        }
        if (item == "RG")
        {
            if (amount > RGI)
            {
                increment = increment - remove;
                increment = increment + amount;
                FI = amount;
            }
        }
        if (item == "RS")
        {
            if (amount > RFI)
            {
                increment = increment - remove;
                increment = increment + amount;
                FI = amount;
            }
        }
        if (item == "LS")
        {
            if (amount > LFI)
            {
                increment = increment - remove;
                increment = increment + amount;
                FI = amount;
            }
        }
    }

}
