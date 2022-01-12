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

    public bool[] RGlovesUnlocked = { true, false, false, false, false, false, false };
    public bool[] LGlovesUnlocked = { true, false, false, false, false, false, false };

    public bool[] RShoeUnlocked = { true, false, false, false, false, false, false };
    public bool[] LShoeUnlocked = { true, false, false, false, false, false, false };
    public bool[] HatsUnlocked = { true, false, false, false, false, false, false, false, false, false };
    public Dictionary<string, int> upgrades = new Dictionary<string, int>();
}
