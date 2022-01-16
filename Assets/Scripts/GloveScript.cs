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
    public ClickerScript cs;
    public GloveBuyScript gbs;
    private float RpreviousIncrement;
    private float LpreviousIncrement;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeHand(int hand)
    {
        if (RHbool)
        {
            sr.sprite = righthand[hand];
            currentRH = hand;
            AddIncrement(hand);
        }
        else
        {
            sr.sprite = lefthand[hand];
            currentLH = hand;
            AddIncrement(hand);
        }
    }

    public void AddIncrement(int hand)
    {
        if (RHbool)
        {
            cs.Downgrade(RpreviousIncrement);
            cs.Upgrade(gbs.RGaddedIncrement[hand]);
            RpreviousIncrement = gbs.RGaddedIncrement[hand];
        }
        else
        {
            cs.Downgrade(LpreviousIncrement);
            cs.Upgrade(gbs.LGaddedIncrement[hand]);
            LpreviousIncrement = gbs.LGaddedIncrement[hand];
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

    public void Buy()
    {

    }
}
