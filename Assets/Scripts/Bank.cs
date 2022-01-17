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
    public int toysSpawned;

    private int ballSpawn;
    private int teddySpawn;
    private int gameBoySpawn;

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
        text.text = "$" + Money.ToString("n0") + "- " + increment + "/s";
        if (i < 2000 && i < toysSpawned)
        {
            index = Random.Range(0, locations.Length);
            currentPoint = locations[index];
            i++;
            if (ballSpawn < ballsSpawned)
            {
                Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
                ballSpawn++;
                toysSpawned++;
            }
            if (teddySpawn < teddySpawned)
            {
                Instantiate(teddy, currentPoint.transform.position, Quaternion.identity);
                teddySpawn++;
                toysSpawned++;
            }
            if (gameBoySpawn < gameBoySpawned)
            {
                Instantiate(gameBoy, currentPoint.transform.position, Quaternion.identity);
                gameBoySpawn++;
                toysSpawned++;
            }
        }
    }
}
