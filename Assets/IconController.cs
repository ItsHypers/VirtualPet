using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconController : MonoBehaviour
{
    public Sprite[] hungerSprites;
    public Sprite[] happinessSprites;
    public Survival surv;
    public Image hunger;
    public Image happiness;

    private void Update()
    {

        if(surv.Hunger >= 75)
        {
            hunger.sprite = hungerSprites[0];        
        }
        else if(surv.Hunger >= 25)
        {
            hunger.sprite = hungerSprites[1];
        }
        else
        {
            hunger.sprite = hungerSprites[2];
        }

        if (surv.Happiness < 75 && surv.Happiness > 25)
        {
            happiness.sprite = happinessSprites[1];
        }
        else if (surv.Happiness < 25)
        {
            happiness.sprite = happinessSprites[2];
        }
        else
        {
            happiness.sprite = happinessSprites[0];
        }
    }
}
