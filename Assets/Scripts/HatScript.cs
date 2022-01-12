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

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeHat(int hat)
    {
        sr.sprite = hats[hat];
        currentHat = hat;
    }

    public void RandomHat()
    {
        randomInt = Random.Range(0, hats.Length);
        ChangeHat(randomInt);
    }
}
