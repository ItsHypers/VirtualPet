using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Survival : MonoBehaviour
{
    [Header("Player Health")]
    public float MaxHealth = 100f;
    public float Health = 100f;
    public float healthDecrease;
    public TMP_Text HealthText;

    [Header("Player Hunger")]
    public float maxHunter = 100f;
    public float Hunger = 100f;
    public float hungerDecrease;
    public float hungerDecreaseSave;
    public TMP_Text HungerText;

    [Header("Player Happiness")]
    public float maxHappiness = 100f;
    public float Happiness = 100f;
    public float happinessDecrease;
    public float happinessDecreaseSave;
    public TMP_Text HappinessText;
    public SaveObject so;

    private void Start()
    {
        happinessDecrease = happinessDecreaseSave;
        hungerDecrease = hungerDecreaseSave;
        so.hunger = Hunger;
        so.health = Health;
        so.happiness = Happiness;
    }
    private void Update()
    {
        if (Hunger <= 0f)
        {
            hungerDecrease = 0f;
            Hunger = 0f;
        }
        else
        {
            hungerDecrease = hungerDecreaseSave;
        }
        if (Hunger < 30)
        {
            happinessDecrease = 1.2f;
        }
        if(Hunger > 30)
        {
            happinessDecrease = happinessDecreaseSave;
        }
        if (Happiness <= 0f)
        {
            happinessDecrease = 0f;
            Happiness = 0f;
        }
        Hunger = Hunger - hungerDecrease * Time.deltaTime;
        Health = Health - healthDecrease * Time.deltaTime;
        Happiness = Happiness - happinessDecrease * Time.deltaTime;

        HealthText.text = (Health / MaxHealth * 100).ToString("F0") + "%";
        HungerText.text = (Hunger / maxHunter * 100).ToString("F0") + "%";
        HappinessText.text = (Happiness / maxHappiness * 100).ToString("F0") + "%";

        if (Hunger <= 0f && Happiness <= 0f)
        {
            healthDecrease = 0.15f;
        }
        else if (Hunger <= 0f)
        {
            healthDecrease = 0.05f;
        }
        else if(Happiness <= 0f)
        {
            healthDecrease = 0.05f;
        }
        else
        {
            healthDecrease = 0f;
        }
    }
}
