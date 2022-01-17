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
    public GameObject gameBoyObject;
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
    public int toysSpawned;

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
        teddyText.text = "Teddy" + "-" + Environment.NewLine + "$" + teddyPrice + "+" + teddyRefilled;
        gameBoyText.text = "GameBoy" + "-" + Environment.NewLine + "$" + gameBoyPrice + "+" + gameBoyRefilled;

        MailText.text = "Junk Mail" + "-" + Environment.NewLine + "$" + JunkMailPrice + "+" + JunkMailRefilled;
        CreditCardText.text = "Credit Cards" + "-" + Environment.NewLine + "$" + CreditCardPrice + "+" + CreditCardRefilled;
        NFTText.text = "Credit Cards" + "-" + Environment.NewLine + "$" + NFTPrice + "+" + NFTRefilled;
    }
    public void BallBuy()
    {
        if (bs.Money >= ballPrice)
        {
            surv.Happiness += ballRefilled;
            bs.Money -= ballPrice;
            if (toysSpawned < 2000)
            {
                index = UnityEngine.Random.Range(0, locations.Length);
                currentPoint = locations[index];
                Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
                ballsSpawned++;
                toysSpawned++;
            }
        }
    }

    public void TeddyBuy()
    {
        if (bs.Money >= teddyPrice)
        {
            surv.Happiness += teddyRefilled;
            bs.Money -= teddyPrice;
            if (toysSpawned < 2000)
            {
                index = UnityEngine.Random.Range(0, locations.Length);
                currentPoint = locations[index];
                Instantiate(teddy, currentPoint.transform.position, Quaternion.identity);
                teddySpawned++;
                toysSpawned++;
            }
        }
    }

    public void gameBoyBuy()
    {
        if (bs.Money >= gameBoyPrice)
        {
            surv.Happiness += gameBoyRefilled;
            bs.Money -= gameBoyPrice;
            if (toysSpawned < 2000)
            {
                index = UnityEngine.Random.Range(0, locations.Length);
                currentPoint = locations[index];
                Instantiate(gameBoyObject, currentPoint.transform.position, Quaternion.identity);
                gameBoySpawned++;
                toysSpawned++;
            }
        }
    }

    public void ManualBallSpawn()
    {
        int spawned = 0;
        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("ball");
        GameObject[] teddys;
        teddys = GameObject.FindGameObjectsWithTag("teddy");
        GameObject[] gameBoy;
        gameBoy = GameObject.FindGameObjectsWithTag("gameboy");
        foreach (GameObject ball in balls)
        {
            spawned++;
        }
        foreach (GameObject teddy in teddys)
        {
            spawned++;
        }
        foreach (GameObject gameboy in gameBoy)
        {
            spawned++;
        }
        if (spawned > toysSpawned)
        {
            foreach(GameObject ball in balls)
            {
                Destroy(ball);
            }
            foreach (GameObject teddy in teddys)
            {
                Destroy(teddy);
            }
            foreach (GameObject game in gameBoy)
            {
                Destroy(game);
            }
            spawned = 0;
        }
        while (spawned < toysSpawned)
        {
            index = UnityEngine.Random.Range(0, locations.Length);
            currentPoint = locations[index];
            int randomNumber = UnityEngine.Random.Range(0, 3);
            if(randomNumber == 0)
            {
                Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
                spawned++;
            }
            if (randomNumber == 1)
            {
                Instantiate(teddy, currentPoint.transform.position, Quaternion.identity);
                spawned++;
            }
            if (randomNumber == 2)
            {
                Instantiate(gameBoyObject, currentPoint.transform.position, Quaternion.identity);
                spawned++;
            }
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

    public void NFTs()
    {
        if (bs.Money >= NFTPrice)
        {
            bs.Money -= NFTPrice;
            surv.Hunger += NFTRefilled;
            StartCoroutine(ac.Eat());
        }
    }


}
