using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerScript : MonoBehaviour
{

    public Bank bs;
    public int DelayAmount = 1; // Second count
    protected float Timer;
    public float increment;
    private void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0); 
            increment = 1;
        }
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            bs.Money = bs.Money + increment;
        }
    }

    private void Upgrade(float amount)
    {
        increment = increment + amount;
    }
}
