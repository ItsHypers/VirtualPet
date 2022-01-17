using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconController : MonoBehaviour
{
    public Sprite[] hungerSprites;
    public Sprite[] happinessSprites;
    public Sprite[] healthSprites;

    public Survival surv;

    public Image hunger;
    public Image happiness;
    public Image health;

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

        if (surv.Health >= 75)
        {
            health.sprite = healthSprites[0];
        }
        else if (surv.Health >= 25)
        {
            health.sprite = healthSprites[1];
        }
        else
        {
            health.sprite = healthSprites[2];
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
