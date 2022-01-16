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

    GameObject[] locations;
    public int ballsSpawned;
    public int teddySpawned;
    public int gameBoySpawned;
    GameObject currentPoint;
    public GameObject ball;
    public GameObject teddy;
    public GameObject gameBoy;
    public float increment;

    int index;
    int i = 0;

    private void Start()
    {
        locations = GameObject.FindGameObjectsWithTag("location");
    }
    private void Update()
    {
        text.text = "$" + Money.ToString() + "- " + increment + "/s";
        while (i < ballsSpawned && i <= 2000)
        {
            index = Random.Range(0, locations.Length);
            currentPoint = locations[index];
            i++;
            Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
        }
        while (i < teddySpawned && i <= 2000)
        {
            index = Random.Range(0, locations.Length);
            currentPoint = locations[index];
            i++;
            Instantiate(teddy, currentPoint.transform.position, Quaternion.identity);
        }
        while (i < gameBoySpawned && i <= 2000)
        {
            index = Random.Range(0, locations.Length);
            currentPoint = locations[index];
            i++;
            Instantiate(gameBoy, currentPoint.transform.position, Quaternion.identity);
        }
    }
}
