using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ImageHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject menu;
    public Upgrade upgrade;
    public TMP_Text upgradeNameText;
    public TMP_Text upgradeDescription;
    public TMP_Text upgradePrice;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (upgrade.unlocked)
        {
            upgradePrice.text = "Price: " + "Bought!";
        }
        else
        {
            upgradePrice.text = "Price: " + "$" + upgrade.cost;
        }
        upgradeNameText.text = upgrade.upgradeName;
        upgradeDescription.text = upgrade.description;
        menu.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        menu.SetActive(false);
    }

}
