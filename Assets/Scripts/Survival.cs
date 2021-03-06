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
    public Upgrade[] upgrades;
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
    public bool paused;
    public Animator playerAnim;
    public GameObject healthCanvas;
    public GameObject death;
    private bool dead;
    public SaveScript ss;
    public int upgradedUnlocked;
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
        if (upgradedUnlocked <= 5)
        {
            healthCanvas.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        }
        if (upgradedUnlocked >= 6)
        {
            healthCanvas.transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        }
        if (!paused)
        {
            if (Health > 100)
            {
                Health = 100;
            }
            if (Hunger > 100)
            {
                Hunger = 100;
            }
            if (Happiness > 100)
            {
                Happiness = 100;
            }
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
            if (Hunger > 30)
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

            if (Hunger <= 0f && Happiness <= 0f)
            {
                healthDecrease = 0.3f;
            }
            else if (Hunger <= 0f)
            {
                healthDecrease = 0.1f;
            }
            else if (Happiness <= 0f)
            {
                healthDecrease = 0.1f;
            }
            else
            {
                healthDecrease = 0f;
            }
            if (Hunger > 75 && Happiness > 75)
            {
                if (Health >= 100)
                {
                    healthDecrease = 0f;
                }
                else
                {
                    healthDecrease = -0.2f;
                }
            }
            if (Health <= 0 && !dead)
            {
                paused = true;
                playerAnim.SetBool("death", true);
                playerAnim.SetTrigger("dead");
                gameObject.GetComponent<AI>().enabled = false;
                StartCoroutine(deathTimer());
                Debug.Log("death");
                dead = true;

            }
        }
        HealthText.text = (Health / MaxHealth * 100).ToString("F0") + "%";
        HungerText.text = (Hunger / maxHunter * 100).ToString("F0") + "%";
        HappinessText.text = (Happiness / maxHappiness * 100).ToString("F0") + "%";
    }


    private void OnMouseEnter()
    {
        Debug.Log("Name: " + gameObject.name);
        healthCanvas.SetActive(true);
    }
    private void OnMouseExit()
    {
        Debug.Log("Name: " + gameObject.name);
        healthCanvas.SetActive(false);
    }

    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(5);
        death.SetActive(true);
    }

}

