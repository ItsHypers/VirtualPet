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
    public EndingSeq es;
    public SuppliesBuyingScript sbs;
    public Survival ss;


    private void Awake()
    {
        if(upgrade.unlocked)
        {
            cs.Upgrade(upgrade.increase, 0, "upgrade");
            text.text = upgrade.upgradeName + " Bought!";
            player.transform.localScale += new Vector3(upgrade.scaleAmount, upgrade.scaleAmount, upgrade.scaleAmount);
            sbs.UpdatePrice(upgrade.tier1shop, upgrade.tier2shop, upgrade.tier3shop);
            cs.UpdateButton(upgrade.clickerUpgrades);
            ss.upgradedUnlocked += 1;
        }
    }
    public void OnPurchase()
    {
        if (bs.Money >= upgrade.cost && !upgrade.unlocked)
        {
            text.text = upgrade.upgradeName + " Bought!";
            bs.Money -= upgrade.cost;
            cs.Upgrade(upgrade.increase, 0, "upgrade");
            player.transform.localScale += new Vector3(upgrade.scaleAmount, upgrade.scaleAmount, upgrade.scaleAmount);
            upgrade.unlocked = true;
            ss.upgradedUnlocked += 1;
            if (upgrade.upgradeName == "AI")
            {
                es.EndGameStart();
            }
            sbs.UpdatePrice(upgrade.tier1shop, upgrade.tier2shop, upgrade.tier3shop);
            cs.UpdateButton(upgrade.clickerUpgrades);
        }
    }
}
