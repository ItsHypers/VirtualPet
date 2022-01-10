using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveScript : MonoBehaviour
{
    public Sprite[] righthand;
    public Sprite[] lefthand;
    private int randomInt;
    private SpriteRenderer sr;
    public bool RHbool;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (RHbool)
        {
            if (PlayerPrefs.HasKey("currentRF"))
            {
                sr.sprite = righthand[PlayerPrefs.GetInt("currentRF")];
            }
            else
            {
                sr.sprite = righthand[0];
            }
        }
        else
        {
            if (PlayerPrefs.HasKey("currentLF"))
            {
                sr.sprite = lefthand[PlayerPrefs.GetInt("currentLF")];
            }
            else
            {
                sr.sprite = lefthand[0];
            }
        }
    }

    private void ChangeHand(int hand)
    {
        if (RHbool)
        {
            sr.sprite = righthand[hand];
            PlayerPrefs.SetInt("currentRF", hand);
        }
        else
        {
            sr.sprite = lefthand[hand];
            PlayerPrefs.SetInt("currentLF", hand);
        }
    }

    public void RandomHand()
    {
        if(RHbool)
        {
            randomInt = Random.Range(0, righthand.Length - 1);
            ChangeHand(randomInt);
        }
        else
        {
            randomInt = Random.Range(0, lefthand.Length);
            ChangeHand(randomInt);
        }
    }
}
