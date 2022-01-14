using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UpgradeItem : MonoBehaviour
{
    public Upgrade upgrade;
    public TMP_Text text;
    public Bank bs;
    public ClickerScript cs;
    public GameObject player;


    private void Start()
    {
        if(upgrade.unlocked)
        {
            cs.Upgrade(upgrade.increase);
        }
    }
    public void OnPurchase()
    {
        if (bs.Money >= upgrade.cost)
        {
            text.text = upgrade.upgradeName + " -" + Environment.NewLine + "Bought!";
            cs.Upgrade(upgrade.increase);
            player.transform.localScale += new Vector3(upgrade.scaleAmount, upgrade.scaleAmount, upgrade.scaleAmount);
            upgrade.unlocked = true;
        }
    }
}
