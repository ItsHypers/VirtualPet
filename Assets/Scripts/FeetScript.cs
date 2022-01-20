using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetScript : MonoBehaviour
{
    public Sprite[] rightfoot;
    public Sprite[] leftfoot;
    private int randomInt;
    public int currentRF;
    public int currentLF;
    private SpriteRenderer sr;
    public bool RFbool;
    public SaveObject so;
    public ClickerScript cs;
    public ShoeBuyScript sbs;
    private float RScurrentIncrement;
    private float LScurrentIncrement;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeFoot(int foot)
    {
        if (RFbool)
        {
            sr.sprite = rightfoot[foot];
            currentRF = foot;
            AddIncrement(foot);
        }
        else
        {
            sr.sprite = leftfoot[foot];
            currentLF = foot;
            AddIncrement(foot);
        }
    }
    public void AddIncrement(int foot)
    {
        if (RFbool)
        {
            if (sbs.RSaddedIncrement[foot] > RScurrentIncrement)
            {
                cs.Upgrade(sbs.RSaddedIncrement[foot], "RS");
                RScurrentIncrement = sbs.RSaddedIncrement[foot];
            }
        }
        else
        {
            if (sbs.LSaddedIncrement[foot] > LScurrentIncrement)
            {
                cs.Upgrade(sbs.LSaddedIncrement[foot], "LS");
                LScurrentIncrement = sbs.LSaddedIncrement[foot];
            }
        }
    }

    public void RandomFoot()
    {
        if(RFbool)
        {
            randomInt = Random.Range(0, rightfoot.Length);
            ChangeFoot(randomInt);
        }
        else
        {
            randomInt = Random.Range(0, leftfoot.Length);
            ChangeFoot(randomInt);
        }
    }
}
