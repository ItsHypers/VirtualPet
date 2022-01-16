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
    GameObject currentPoint;
    public GameObject ball;
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
    }
}
