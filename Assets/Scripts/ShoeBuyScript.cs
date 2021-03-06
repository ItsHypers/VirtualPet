using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ShoeBuyScript : MonoBehaviour
{
    [Header("Right Gloves")]
    public bool[] RShoeUnlocked;
    public TMP_Text[] RightText;
    public string[] RSNames;
    public int[] RSInts;
    public float[] RSPrice;
    public float[] RSaddedIncrement;

    [Space(10)]
    [Header("Left Gloves")]
    public bool[] LShoeUnlocked;
    public TMP_Text[] LeftText;
    public string[] LSNames;
    public int[] LSInts;
    public float[] LSPrice;
    public float[] LSaddedIncrement;

    public Bank BS;
    public FeetScript RSS;
    public FeetScript LSS;

    private void Start()
    {
        foreach (int i in RSInts)
        {
            if (i != 0)
            {
                if (RShoeUnlocked[i])
                {
                    RightText[i].text = RSNames[i] + "-" + Environment.NewLine + "Bought!" + " + " + RSaddedIncrement[i] + "/s";
                }
                else
                {
                    RightText[i].text = RSNames[i] + "-" + Environment.NewLine + "$" + RSPrice[i] + " + " + RSaddedIncrement[i] + "/s";
                }
            }
        }

        foreach (int i in LSInts)
        {
            if (i != 0)
            {
                if (LShoeUnlocked[i])
                {
                    LeftText[i].text = LSNames[i] + "-" + Environment.NewLine + "Bought!" + " + " + LSaddedIncrement[i] + "/s";
                }
                else
                {
                    LeftText[i].text = LSNames[i] + "-" + Environment.NewLine + "$" + LSPrice[i] + " + " + LSaddedIncrement[i] + "/s";
                }
            }
        }
    }
    public void RightShoeClick(int Array)
    {
        foreach (int gloveInts in RSInts)
        {
            if (gloveInts == Array)
            {
                if (!RShoeUnlocked[Array])
                {
                    if (BS.Money > RSPrice[Array])
                    {
                        RightText[Array].text = RSNames[Array] + "-" + Environment.NewLine + "Bought!" + " + " + RSaddedIncrement[Array] + "/s";
                        BS.Money -= RSPrice[Array];
                        RShoeUnlocked[Array] = true;
                        RSS.ChangeFoot(Array);
                    }
                }
                else
                {
                    RSS.ChangeFoot(Array);
                }
            }
        }
    }

    public void LeftShoeClick(int Array)
    {
        foreach (int gloveInts in LSInts)
        {
            if (gloveInts == Array)
            {
                if (!LShoeUnlocked[Array])
                {
                    if (BS.Money > LSPrice[Array])
                    {
                        LeftText[Array].text = LSNames[Array] + "-" + Environment.NewLine + "Bought!" + " + " + LSaddedIncrement[Array] + "/s";
                        BS.Money -= LSPrice[Array];
                        LShoeUnlocked[Array] = true;
                        LSS.ChangeFoot(Array);
                    }
                }
                else
                {
                    LSS.ChangeFoot(Array);
                }
            }
        }
    }
}
