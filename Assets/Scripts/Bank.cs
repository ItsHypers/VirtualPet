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
    int ballsSpawned;
    GameObject currentPoint;
    public GameObject ball;

    int index;
    int i = 0;

    private void Start()
    {
        ballsSpawned = so.ballsSpawned;
        locations = GameObject.FindGameObjectsWithTag("location");
        while (i < ballsSpawned && i <= 2000)
        {
            index = Random.Range(0, locations.Length);
            currentPoint = locations[index];
            i++;
            Instantiate(ball, currentPoint.transform.position, Quaternion.identity);
        }
        if (!PlayerPrefs.HasKey("currency"))
        {
            PlayerPrefs.SetString("currency", "£");
        }
    }
    private void Update()
    {
        text.text = PlayerPrefs.GetString("currency") + Money.ToString();
    }
}
