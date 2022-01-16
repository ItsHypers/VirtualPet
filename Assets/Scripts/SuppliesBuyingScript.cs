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

    public Upgrade[] allUpgrades;
    private int upgradeUnlock;

    [Header("Save")]
    public int ballsSpawned;

    public AnimatorController ac;

    private void Start()
    {
        UpdatePrice();
       
    }

    public void UpdatePrice()
    {
        foreach (Upgrade upgrade in allUpgrades)
        {
            if (upgrade.unlocked)
            {
                upgradeUnlock++;
                Debug.Log(upgradeUnlock);
            }
        }

        if (upgradeUnlock == 0)
        {
            ballPrice = 300;
            JunkMailPrice = 300;
            CreditCardPrice = 600;
        }
        if (upgradeUnlock == 1)
        {
            ballPrice = 1500;
            JunkMailPrice = 1500;
            CreditCardPrice = 3000;
        }
        if (upgradeUnlock == 2)
        {
            ballPrice = 3000;
            JunkMailPrice = 3000;
            CreditCardPrice = 6000;
        }
        if (upgradeUnlock == 3)
        {
            ballPrice = 6000;
            JunkMailPrice = 6000;
            CreditCardPrice = 12000;
        }
        if (upgradeUnlock == 4)
        {
            ballPrice = 12000;
            JunkMailPrice = 12000;
            CreditCardPrice = 24000;
        }
        if (upgradeUnlock == 5)
        {
            ballPrice = 24000;
            JunkMailPrice = 24000;
            CreditCardPrice = 48000;
        }
        if (upgradeUnlock == 6)
        {
            ballPrice = 60000;
            JunkMailPrice = 60000;
            CreditCardPrice = 120000;
        }
        if (upgradeUnlock == 7)
        {
            ballPrice = 135000;
            JunkMailPrice = 135000;
            CreditCardPrice = 270000;
        }
        if (upgradeUnlock == 8)
        {
            ballPrice = 255000;
            JunkMailPrice = 255000;
            CreditCardPrice = 510000;
        }
        if (upgradeUnlock == 9)
        {
            ballPrice = 496800;
            JunkMailPrice = 496800;
            CreditCardPrice = 993600;
        }
        ballText.text = "Ball" + "-" + Environment.NewLine + "$" + ballPrice + " - " + "+" + ballRefilled;
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
