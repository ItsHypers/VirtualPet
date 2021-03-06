using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class HatsBuyScript : MonoBehaviour
{
    [Header("Hats")]
    public bool[] hatsUnlocked;
    public TMP_Text[] Text;
    public string[] HatNames;
    public int[] HatInts;
    public float[] HatPrice;
    public float[] addedIncrement;

    public Bank BS;
    public HatScript HS;
    public SaveObject so;
    private void Start()
    {
        foreach (int i in HatInts)
        {
            if (i != 0)
            {
                if (hatsUnlocked[i])
                {
                    Text[i].text = HatNames[i] + "-" + Environment.NewLine + "Bought!" + " + " + addedIncrement[i] + "/s";
                }
                else
                {
                    Text[i].text = HatNames[i] + "-" + Environment.NewLine + "$" + HatPrice[i] + " + " + addedIncrement[i] + "/s";
                }
            }
        }
    }
    public void BuyHat(int Array)
    {
        foreach (int HatInts in HatInts)
        {
            if(HatInts == Array)
            {
                if (!hatsUnlocked[Array])
                {
                    if (BS.Money > HatPrice[Array])
                    {
                        Text[Array].text = HatNames[Array] + "-" + Environment.NewLine + "Bought!" + " + " + addedIncrement[Array] + "/s";
                        BS.Money -= HatPrice[Array];
                        hatsUnlocked[Array] = true;
                        HS.ChangeHat(Array);
                    }
                }
                else
                {
                    HS.ChangeHat(Array);
                }
            }
        }
    }
}
