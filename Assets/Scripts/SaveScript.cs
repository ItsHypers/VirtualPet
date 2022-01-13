using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public SaveObject so;
    public Survival survival;
    public Bank bs;
    public HatScript hs;
    public FaceScript fs;
    public GloveScript[] gs;
    public FeetScript[] FootS;
    public GloveBuyScript GBS;
    public ShoeBuyScript SBS;
    public HatsBuyScript HBS;
    public FaceBuyScript FBS;
    public SuppliesBuyingScript SUBS;

    public bool manualSave;

    public int autoSaveTimer = 10; // Second count
    [SerializeField]
    protected float Timer;

    private void Start()
    {
        so = SaveManager.Load();
        survival.Health = so.health;
        survival.Hunger = so.hunger;
        survival.Happiness = so.happiness;
        bs.Money = so.money;

        hs.ChangeHat(so.hat);
        fs.ChangeFace(so.face);
        SUBS.ballsSpawned = so.ballsSpawned;

        foreach (GloveScript HS in gs)
        {
            if (HS.RHbool)
            {
                HS.ChangeHand(so.rightHand);
            }
            else
                HS.ChangeHand(so.leftFoot);
        }

        foreach (FeetScript FS in FootS)
        {
            if (FS.RFbool)
                FS.ChangeFoot(so.rightFoot);
            else
                FS.ChangeFoot(so.leftFoot);
        }

        HBS.hatsUnlocked = so.HatsUnlocked;
        FBS.faceUnlocked = so.FaceUnlocked;

        SBS.RShoeUnlocked = so.RShoeUnlocked;
        SBS.LShoeUnlocked = so.LShoeUnlocked;

        GBS.RGlovesUnlocked = so.RGlovesUnlocked;
        GBS.LGlovesUnlocked = so.LGlovesUnlocked;
    }
    private void Update()
    {

        Timer += Time.deltaTime;
        if (Timer >= autoSaveTimer || manualSave)
        {
            Timer = 0f;
            so.health = survival.Health;
            so.hunger = survival.Hunger;
            so.happiness = survival.Happiness;
            so.money = bs.Money;

            so.ballsSpawned = SUBS.ballsSpawned;
            so.hat = hs.currentHat;
            so.face = fs.currentFace;

            foreach (GloveScript HS in gs)
            {
                if (HS.RHbool)
                {
                    so.rightHand = HS.currentRH;
                }
                else
                    so.leftHand = HS.currentLH;
            }

            foreach (FeetScript FS in FootS)
            {
                if (FS.RFbool)
                    so.rightFoot = FS.currentRF;
                else
                    so.leftFoot = FS.currentLF;
            }

            so.HatsUnlocked = HBS.hatsUnlocked;
            so.FaceUnlocked = FBS.faceUnlocked;

            so.LGlovesUnlocked = GBS.LGlovesUnlocked;
            so.RGlovesUnlocked = GBS.RGlovesUnlocked;

            so.RShoeUnlocked = SBS.RShoeUnlocked;
            so.LShoeUnlocked = SBS.LShoeUnlocked;

            so.upgrades["sim"] = 1;
            so.upgrades["card"] = 0;
            so.upgrades["hello"] = 1;
            SaveManager.Save(so);
            manualSave = false;
        }
    }
}
