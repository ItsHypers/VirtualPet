using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour
{
    public Sprite[] hats;
    private int randomInt;
    public int currentHat;
    private SpriteRenderer sr;
    public SaveObject so;
    public ClickerScript cs;
    public HatsBuyScript hbs;
    private float previousIncrement;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeHat(int hat)
    {
        sr.sprite = hats[hat];
        currentHat = hat;
        AddIncrement(hat);
    }

    public void AddIncrement(int face)
    {
        cs.Downgrade(previousIncrement);
        cs.Upgrade(hbs.addedIncrement[face]);
        previousIncrement = hbs.addedIncrement[face];
    }

    public void RandomHat()
    {
        randomInt = Random.Range(0, hats.Length);
        ChangeHat(randomInt);
    }
}
