using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class FaceBuyScript : MonoBehaviour
{
    [Header("Face")]
    public bool[] faceUnlocked;
    public TMP_Text[] Text;
    public string[] FaceNames;
    public int[] FaceInts;
    public float[] FacePrice;

    public Bank BS;
    public FaceScript FS;
    public SaveObject so;
    private void Start()
    {
        foreach (int i in FaceInts)
        {
            if (i != 0)
            {
                if (faceUnlocked[i])
                {
                    Text[i].text = FaceNames[i] + "-" + Environment.NewLine + "Bought!";
                }
            }
        }
    }
    public void BuyFace(int Array)
    {
        foreach (int FaceInts in FaceInts)
        {
            if (FaceInts == Array)
            {
                if (!faceUnlocked[Array])
                {
                    if (BS.Money > FacePrice[Array])
                    {
                        Text[Array].text = FaceNames[Array] + "-" + Environment.NewLine + "Bought!";
                        BS.Money -= FacePrice[Array];
                        faceUnlocked[Array] = true;
                        FS.ChangeFace(Array);
                    }
                }
                else
                {
                    FS.ChangeFace(Array);
                }
            }
        }
    }
}
