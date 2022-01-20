using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScript : MonoBehaviour
{
    public Sprite[] faces;
    private int randomInt;
    public int currentFace;
    private SpriteRenderer sr;
    public SaveObject so;
    public ClickerScript cs;
    public FaceBuyScript fbs;
    private float currentIncrement;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeFace(int face)
    {
        sr.sprite = faces[face];
        currentFace = face;
        AddIncrement(face);
    }
    public void AddIncrement(int face)
    {
        if (fbs.addedIncrement[face] > currentIncrement)
        {
            cs.Upgrade(fbs.addedIncrement[face], "face");
            currentIncrement = fbs.addedIncrement[face];
        }
    }

    public void RandomFace()
    {
        randomInt = Random.Range(0, faces.Length);
        ChangeFace(randomInt);
    }
}
