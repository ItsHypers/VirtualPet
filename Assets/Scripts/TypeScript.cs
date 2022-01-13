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
    public Survival surv;
    public GameObject pc;
    // Update is called once per frame

    private void Start()
    {
        displayStr = "public class VirusCreation" + Environment.NewLine + "{" + Environment.NewLine + "   public string name = \"BOB\";" + Environment.NewLine + "   public int Age = 0;" + Environment.NewLine + "   public SpriteRenderer virusMan;" + Environment.NewLine + Environment.NewLine + "   public void Explanation:" + Environment.NewLine + "   {" + Environment.NewLine + "      string Reason = \"Creating a Virus to create passive income\";" + Environment.NewLine + "      string Upgrades = \"Upgrade the Virus to create more passive income per second\";" + Environment.NewLine + "      string Cosmetics = \"Decorate your Virus with custom clothes\";" + Environment.NewLine + "      string Food = \"Keep your virus alive by feeding it... computer food\";" + Environment.NewLine + "      string Happiness = \"Keep your virus happy by buying it toys from the shop\";" + Environment.NewLine + "      Instantiate(virusMan);" + Environment.NewLine + "      Initiate Program? (Y/N);" + Environment.NewLine + "   }" + Environment.NewLine + "}";

        if(inStartScreen)
            pc.SetActive(true);
        else
            pc.SetActive(false);

    }
    void Update()
    {
        if (inStartScreen)
        {
            surv.paused = true;
            if (typedLength != displayStr.Length)
            {
                if (Input.anyKeyDown)
                {
                    typedLength += 1;
                    displayStr.Substring(0, typedLength);
                    written = displayStr.Substring(0, typedLength);
                    text.text = written;
                    Debug.Log(written);
                }
            }
            if(typedLength == displayStr.Length && Input.GetKeyDown(KeyCode.Y))
            {
                inStartScreen = false;
                surv.paused = false;
                pc.SetActive(false);
            }
        }
    }
}