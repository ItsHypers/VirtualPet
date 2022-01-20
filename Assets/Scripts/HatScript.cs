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
    private float currentIncrement;

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

    public void AddIncrement(int hat)
    {
        if (hbs.addedIncrement[hat] > currentIncrement)
        {
            cs.Upgrade(hbs.addedIncrement[hat], "hat");
            previousIncrement = hbs.addedIncrement[hat];
        }
    }

    public void RandomHat()
    {
        randomInt = Random.Range(0, hats.Length);
        ChangeHat(randomInt);
    }
}
