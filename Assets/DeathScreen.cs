using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{

    public SaveScript ss;
    public Survival surv;
    public Animator Playeranim;
    public AI aiScript;
    public void openMainMenu()
    {
        surv.Health = 10;
        if (surv.Hunger >= 0)
        {
            surv.Hunger = 10;
        }
        if (surv.Happiness >= 0)
        {
            surv.Happiness = 10;
        }
        ss.manualSave = true;
        SceneManager.LoadScene(0);
    }

    public void LoadPrevious()
    {
        Playeranim.SetBool("death", false);
        surv.paused = false;
        surv.GetComponent<AI>().enabled = true;
        surv.Health = 10;
        if (surv.Hunger >= 0)
        {
            surv.Hunger = 10;
        }
        if (surv.Happiness >= 0)
        {
            surv.Happiness = 10;
        }
        ss.manualSave = true;
        ss.LoadGame();
        gameObject.SetActive(false);
    }
}
