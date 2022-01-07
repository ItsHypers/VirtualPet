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

    private void Start()
    {
        Health = MaxHealth;
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
        Hunger = Hunger - hungerDecrease * Time.deltaTime;
        Health = Health - healthDecrease * Time.deltaTime;

        HealthSlider.value = Health / MaxHealth;
        HungerSlider.value = Hunger / maxHunter;

        if (Hunger <= 0f)
        {
            healthDecrease = 0.02f;
        }
        else
        {
            healthDecrease = 0f;
        }
    }
}
