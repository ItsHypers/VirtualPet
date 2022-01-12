using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GloveBuyScript : MonoBehaviour
{
    [Header("Right Gloves")]
    public bool[] RGlovesUnlocked;
    public TMP_Text[] RightText;
    public string[] RGNames;
    public int[] RGloveInts;
    public float[] RGlovePrice;

    [Space(10)]
    [Header("Left Gloves")]
    public bool[] LGlovesUnlocked;
    public TMP_Text[] LeftText;
    public string[] LGNames;
    public int[] LGloveInts;
    public float[] LGlovePrice;

    public Bank BS;
    public GloveScript RGS;
    public GloveScript LGS;

    private void Start()
    {
        foreach (int i in RGloveInts)
        {
            if (i != 0)
            {
                if (RGlovesUnlocked[i])
                {
                    RightText[i].text = RGNames[i] + "-" + Environment.NewLine + "Bought!";
                }
            }
        }

        foreach (int i in LGloveInts)
        {
            if (i != 0)
            {
                if (LGlovesUnlocked[i])
                {
                    LeftText[i].text = LGNames[i] + "-" + Environment.NewLine + "Bought!";
                }
            }
        }
    }
    public void RightGloveClick(int Array)
    {
        foreach(int gloveInts in RGloveInts)
        {
            if (gloveInts == Array)
            {
                if (!RGlovesUnlocked[Array])
                {
                    if (BS.Money > RGlovePrice[Array])
                    {
                        RightText[Array].text = RGNames[Array] + "-" + Environment.NewLine + "Bought!";
                        BS.Money -= RGlovePrice[Array];
                        RGlovesUnlocked[Array] = true;
                        RGS.ChangeHand(Array);
                    }
                }
                else
                {
                    RGS.ChangeHand(Array);
                }
            }
        }
    }

    public void LeftGloveClick(int Array)
    {
        foreach (int gloveInts in LGloveInts)
        {
            if (gloveInts == Array)
            {
                if (!LGlovesUnlocked[Array])
                {
                    if (BS.Money > LGlovePrice[Array])
                    {
                        LeftText[Array].text = LGNames[Array] + "-" + Environment.NewLine + "Bought!";
                        BS.Money -= LGlovePrice[Array];
                        LGlovesUnlocked[Array] = true;
                        LGS.ChangeHand(Array);
                    }
                }
                else
                {
                    LGS.ChangeHand(Array);
                }
            }
        }
    }
}
