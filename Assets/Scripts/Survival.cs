using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Survival : MonoBehaviour
{
    [Header("Player Health")]
    public float MaxHealth = 100f;
    public float Health = 0f;
    public float healthDecrease;
    public Slider HealthSlider;

    [Header("Player Hunger")]
    public float maxHunter = 100f;
    public float Hunger = 0f;
    public float hungerDecrease;
    public float hungerDecreaseSave;
    public Slider HungerSlider;

    [Header("Player Happiness")]
    public float maxHappiness = 100f;
    public float Happiness = 0f;
    public float happinessDecrease;
    public float happinessDecreaseSave;
    public Slider HappinessSlider;

    private void Start()
    {
        Health = MaxHealth;
        happinessDecrease = happinessDecreaseSave;
        hungerDecrease = hungerDecreaseSave;
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

        HealthSlider.value = Health / MaxHealth;
        HungerSlider.value = Hunger / maxHunter;
        HappinessSlider.value = Happiness / maxHappiness;

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