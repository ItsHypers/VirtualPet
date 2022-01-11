using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool inShop;
    public GameObject Tabs;
    public GameObject Shop;
    public void openShop()
    {
        if (inShop)
        {
            LeanTween.scale(Tabs, new Vector3(0, 0, 0), 0.4f);
            LeanTween.scale(Shop, new Vector3(0, 0, 0), 0.4f).setOnComplete(setActive);
        }
        else
        {
            Tabs.SetActive(true);
            Shop.SetActive(true);
            LeanTween.scale(Tabs, new Vector3(1, 1, 0), 0.4f);
            LeanTween.scale(Shop, new Vector3(1, 1, 0), 0.4f);
            inShop = true;
        }
    }
    public void setActive()
    {
        if (inShop)
        {
            Tabs.SetActive(false);
            Shop.SetActive(false);
            inShop = false;
        }
        else
        {

        }
    }
}