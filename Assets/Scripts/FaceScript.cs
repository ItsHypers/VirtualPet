using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScript : MonoBehaviour
{
    public Sprite[] faces;
    private int randomInt;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("currentFace"))
        {
            sr.sprite = faces[PlayerPrefs.GetInt("currentFace")];
        }
        else
        {
            sr.sprite = faces[0];
        }
    }

    private void ChangeFace(int face)
    {
        sr.sprite = faces[face];
        PlayerPrefs.SetInt("currentFace", face);
    }

    public void RandomFace()
    {
        randomInt = Random.Range(0, faces.Length);
        ChangeFace(randomInt);
    }
}
