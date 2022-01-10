using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetScript : MonoBehaviour
{
    public Sprite[] rightfoot;
    public Sprite[] leftfoot;
    private int randomInt;
    private SpriteRenderer sr;
    public bool RFbool;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (RFbool)
        {
            if (PlayerPrefs.HasKey("currentRF"))
            {
                sr.sprite = rightfoot[PlayerPrefs.GetInt("currentRF")];
            }
            else
            {
                sr.sprite = rightfoot[0];
            }
        }
        else
        {
            if (PlayerPrefs.HasKey("currentLF"))
            {
                sr.sprite = leftfoot[PlayerPrefs.GetInt("currentLF")];
            }
            else
            {
                sr.sprite = leftfoot[0];
            }
        }
    }

    private void ChangeFoot(int foot)
    {
        if (RFbool)
        {
            sr.sprite = rightfoot[foot];
            PlayerPrefs.SetInt("currentRF", foot);
        }
        else
        {
            sr.sprite = leftfoot[foot];
            PlayerPrefs.SetInt("currentLF", foot);
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
