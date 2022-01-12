using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveObject
{
    public float health;
    public float hunger;
    public float happiness;
    public float money;

    public int hat;
    public int face;
    public int leftHand;
    public int rightHand;
    public int leftFoot;
    public int rightFoot;

    public bool[] RGlovesUnlocked;
    public bool[] LGlovesUnlocked;

    public bool[] RShoeUnlocked;
    public bool[] LShoeUnlocked;

    public bool[] HatsUnlocked;
    public Dictionary<string, int> upgrades = new Dictionary<string, int>();
}
