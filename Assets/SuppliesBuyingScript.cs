using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppliesBuyingScript : MonoBehaviour
{
    public GameObject ball;
    public Survival surv;
    public Bank bs;
    public float ballPrice;
    public GameObject[] locations;
    GameObject currentPoint;
    int index;
    int i = 0;
    public int ballsSpawned;
    private void Update()
    {
        while (i < ballsSpawned && i <= 2000)
        {
            index = Random.Range(0, locations.Length);
            currentPoint = locations[index];
            i++;
            Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
        }
    }
    public void BallBuy()
    {
        if (bs.Money >= ballPrice)
        {
            surv.Happiness += 20;
            bs.Money -= ballPrice;
            index = Random.Range(0, locations.Length);
            currentPoint = locations[index];
            Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
            ballsSpawned++;
        }
    }
}
