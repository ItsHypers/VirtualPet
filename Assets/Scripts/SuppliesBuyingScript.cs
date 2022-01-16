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

    [Header("Teddy")]
    public float teddyPrice;
    [SerializeField]
    private int teddyRefilled;
    public TMP_Text teddyText;

    [Header("GameBoy")]
    public float gameBoyPrice;
    [SerializeField]
    private int gameBoyRefilled;
    public TMP_Text gameBoyText;

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

    [Header("NFTs")]
    public int NFTPrice;
    [SerializeField]
    private int NFTRefilled;
    public TMP_Text NFTText;

    [Header("Scripts")]
    public GameObject ball;
    public GameObject teddy;
    public GameObject gameBoy;
    public Survival surv;
    public Bank bs;

    [Header("Toy Spawner")]
    public GameObject[] locations;
    GameObject currentPoint;
    int index;

    public Upgrade[] allUpgrades;
    private int upgradeUnlock;

    [Header("Save")]
    public int ballsSpawned;
    public int teddySpawned;
    public int gameBoySpawned;

    public AnimatorController ac;
    private int tier1;
    private int tier2;
    private int tier3;


    private void Start()
    {
        if (tier1 == 0)
        {
            tier1 = 30;
            tier2 = 50;
            tier3 = 80;
            UpdatePrice(tier1, tier2, tier3);
        }
    }
    public void UpdatePrice(int tier1, int tier2, int tier3)
    {

        ballPrice = tier1;
        teddyPrice = tier2;
        gameBoyPrice = tier3;

        JunkMailPrice = tier1;
        CreditCardPrice = tier2;
        NFTPrice = tier3;

        ballText.text = "Ball" + "-" + Environment.NewLine + "$" + ballPrice + "+" + ballRefilled;
        MailText.text = "Junk Mail" + "-" + Environment.NewLine + "$" + JunkMailPrice + "+" + JunkMailRefilled;
        CreditCardText.text = "Credit Cards" + "-" + Environment.NewLine + "$" + CreditCardPrice + "+" + CreditCardRefilled;
    }
    public void BallBuy()
    {
        if (bs.Money >= ballPrice)
        {
            surv.Happiness += ballRefilled;
            bs.Money -= ballPrice;
            if (ballsSpawned < 2000)
            {
                index = UnityEngine.Random.Range(0, locations.Length);
                currentPoint = locations[index];
                Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
                ballsSpawned++;
            }
        }
    }

    public void TeddyBuy()
    {
        if (bs.Money >= ballPrice)
        {
            surv.Happiness += ballRefilled;
            bs.Money -= ballPrice;
            if (ballsSpawned < 2000)
            {
                index = UnityEngine.Random.Range(0, locations.Length);
                currentPoint = locations[index];
                Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
                ballsSpawned++;
            }
        }
    }

    public void ManualBallSpawn()
    {
        Debug.Log("balls script ran");
        int spawned = 0;
        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject ball in balls)
        {
            spawned++;
        }
        if(spawned > ballsSpawned)
        {
            foreach(GameObject ball in balls)
            {
                Destroy(ball);
            }
            spawned = 0;
        }
        while (spawned < ballsSpawned)
        {
            index = UnityEngine.Random.Range(0, locations.Length);
            currentPoint = locations[index];
            Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
            spawned++;
        }
    }

    public void JunkMail()
    {
        if(bs.Money >= JunkMailPrice)
        {
            bs.Money -= JunkMailPrice;
            surv.Hunger += JunkMailRefilled;
            StartCoroutine(ac.Eat());
        }
    }
    public void CreditCard()
    {
        if (bs.Money >= CreditCardPrice)
        {
            bs.Money -= CreditCardPrice;
            surv.Hunger += CreditCardRefilled;
            StartCoroutine(ac.Eat());
        }
    }

  
}
