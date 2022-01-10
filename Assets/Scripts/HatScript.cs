using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatScript : MonoBehaviour
{
    public Sprite[] hats;
    private int randomInt;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("currentHat"))
        {
            sr.sprite = hats[PlayerPrefs.GetInt("currentHat")];
        }
        else
        {
            sr.sprite = hats[0];
        }
    }

    private void ChangeHat(int hat)
    {
        sr.sprite = hats[hat];
        PlayerPrefs.SetInt("currentHat", hat);
    }

    public void RandomHat()
    {
        randomInt = Random.Range(0, hats.Length);
        ChangeHat(randomInt);
    }
}
