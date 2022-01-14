using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SuppliesBuyingScript : MonoBehaviour
{
    [Header("Ball")]
    public float ballPrice;
    [SerializeField]
    private int ballRefilled;
    public TMP_Text ballText;

    [Header("JunkMail")]
    public int JunkMailPrice;
    [SerializeField]
    private int JunkMailRefilled;
    public TMP_Text MailText;

    [Header("Credit Card")]
    public int CreditCardPrice;
    [SerializeField]
    private int CreditCardRefilled;
    public TMP_Text CreditCardText;

    [Header("Scripts")]
    public GameObject ball;
    public Survival surv;
    public Bank bs;

    [Header("Toy Spawner")]
    public GameObject[] locations;
    GameObject currentPoint;
    int index;

    [Header("Save")]
    public int ballsSpawned;

    private void Start()
    {
        ballText.text = "Ball" + "-" + Environment.NewLine + "$" + ballPrice;
        MailText.text = "Junk Mail" + "-" + Environment.NewLine + "$" + JunkMailPrice;
        CreditCardText.text = "Credit Cards" + "-" + Environment.NewLine + "$" + CreditCardPrice;
    }
    public void BallBuy()
    {
        if (bs.Money >= ballPrice)
        {
            surv.Happiness += ballRefilled;
            bs.Money -= ballPrice;
            index = UnityEngine.Random.Range(0, locations.Length);
            currentPoint = locations[index];
            Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
            ballsSpawned++;
        }
    }

    public void JunkMail()
    {
        if(bs.Money >= JunkMailPrice)
        {
            bs.Money -= JunkMailPrice;
            surv.Hunger += JunkMailRefilled;
        }
    }
    public void CreditCard()
    {
        if (bs.Money >= CreditCardPrice)
        {
            bs.Money -= CreditCardPrice;
            surv.Hunger += CreditCardRefilled;
        }
    }
}
