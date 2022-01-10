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

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (RFbool)
        {
            sr.sprite = rightfoot[so.rightFoot];
        }
        else
        {
            sr.sprite = leftfoot[so.leftFoot];
        }
    }

    public void ChangeFoot(int foot)
    {
        if (RFbool)
        {
            sr.sprite = rightfoot[foot];
            currentRF = foot;
        }
        else
        {
            sr.sprite = leftfoot[foot];
            currentLF = foot;
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
