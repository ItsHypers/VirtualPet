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
    public SaveObject so;

    private void Start()
    {
        Money = so.money;
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
