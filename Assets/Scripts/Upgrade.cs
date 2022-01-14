using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "item/Upgrade")]
public class Upgrade : ScriptableObject
{
    public int cost;
    public float increase;
    public string upgradeName;
    public float scaleAmount;
    public bool unlocked;
}
