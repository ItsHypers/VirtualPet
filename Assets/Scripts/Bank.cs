using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Bank : MonoBehaviour
{
    public float Money;
    public TMP_Text text;
    private string currency;

    private void Start()
    {
        Money = 0.1f;
        if(!PlayerPrefs.HasKey("currency"))
        {
            PlayerPrefs.SetString("currency", "£");
        }
    }
    private void Update()
    {
        text.text = PlayerPrefs.GetString("currency") + Money.ToString();
    }
}
