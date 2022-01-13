using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TypeScript : MonoBehaviour
{
    public bool inStartScreen;
    private string displayStr;
    public string written;
    public int typedLength;
    public TMP_Text text;
    // Update is called once per frame

    private void Start()
    {
        displayStr = "public class VirusCreation {" + Environment.NewLine + "   public string name = \"BOB\";" + Environment.NewLine + "   public int Age = 0";
    }
    void Update()
    {
        if (inStartScreen)
        {
            if (typedLength != displayStr.Length)
            {
                if(typedLength == 31)
                {
                    written = written + Environment.NewLine;
                }
                if (Input.anyKeyDown)
                {
                    typedLength += 1;
                    displayStr.Substring(0, typedLength);
                    written = displayStr.Substring(0, typedLength);
                    text.text = written;
                    Debug.Log(written);
                }
            }
        }
    }
}