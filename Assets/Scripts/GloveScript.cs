using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveScript : MonoBehaviour
{
    public Sprite[] righthand;
    public Sprite[] lefthand;
    public int currentRH;
    public int currentLH;
    private int randomInt;
    private SpriteRenderer sr;
    public bool RHbool;
    public SaveObject so;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (RHbool)
        {
            sr.sprite = righthand[so.rightHand];
        }
        else
        {
            sr.sprite = lefthand[so.leftHand];
        }
    }

    public void ChangeHand(int hand)
    {
        if (RHbool)
        {
            sr.sprite = righthand[hand];
            currentRH = hand;
        }
        else
        {
            sr.sprite = lefthand[hand];
            currentLH = hand;
        }
    }

    public void RandomHand()
    {
        if(RHbool)
        {
            randomInt = Random.Range(0, righthand.Length);
            ChangeHand(randomInt);
        }
        else
        {
            randomInt = Random.Range(0, lefthand.Length);
            ChangeHand(randomInt);
        }
    }
}
