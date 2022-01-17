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
    public Upgrade[] upgrades;
    public GloveBuyScript GBS;
    public ShoeBuyScript SBS;
    public HatsBuyScript HBS;
    public FaceBuyScript FBS;
    public SuppliesBuyingScript SUBS;
    public Animator autoSave;
    public TypeScript ts;
    public bool manualSave;
    bool AutoSave;

    public int autoSaveTimer; // Second count
    [SerializeField]
    protected float Timer;

    private void Start()
    {
        LoadGame();
    }
    private void Update()
    {
        AutoSave = PlayerPrefs.GetInt("AutoSave", 1) != 0;
        autoSaveTimer = PlayerPrefs.GetInt("autoSaveTimer", 10); 
        if (AutoSave)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= autoSaveTimer || manualSave)
        {
            Timer = 0f;
            autoSave.SetTrigger("saved");
            so.health = survival.Health;
            so.hunger = survival.Hunger;
            so.happiness = survival.Happiness;
            so.money = bs.Money;

            so.ballsSpawned = SUBS.ballsSpawned;
            so.teddySpawned = SUBS.teddySpawned;
            so.gameBoySpawned = SUBS.gameBoySpawned;
            so.toysSpawned = SUBS.toysSpawned;

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

            foreach (Upgrade upgrade in upgrades)
            {
                int boolInt = upgrade.unlocked ? 1 : 0;
                so.upgrades[upgrade.upgradeName] = boolInt;
            }
            SaveManager.Save(so);
            manualSave = false;
        }
    }
    public void LoadGame()
    {
        so = SaveManager.Load();
        ts.playerName = so.playerName;
        survival.Health = so.health;
        survival.Hunger = so.hunger;
        survival.Happiness = so.happiness;
        bs.Money = so.money;

        bs.ballsSpawned = so.ballsSpawned;
        bs.teddySpawned = so.teddySpawned;
        bs.gameBoySpawned = so.gameBoySpawned;
        bs.toysSpawned = so.toysSpawned;

        hs.ChangeHat(so.hat);
        fs.ChangeFace(so.face);
        SUBS.ballsSpawned = so.ballsSpawned;
        SUBS.teddySpawned = so.teddySpawned;
        SUBS.gameBoySpawned = so.gameBoySpawned;
        SUBS.toysSpawned = so.toysSpawned;

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
}
