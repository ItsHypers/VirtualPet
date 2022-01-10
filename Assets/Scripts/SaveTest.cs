using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public SaveObject so;
    public Survival survival;
    public Bank bs;
    public HatScript hs;
    public FaceScript fs;
    public GloveScript[] gs;
    public FeetScript[] FootS;

    private void Start()
    {
        so.health = survival.Health;
        so.hunger = survival.Hunger;
        so.happiness = survival.Happiness;
        so.money = bs.Money;
        so.hat = hs.currentHat;
        so.face = fs.currentFace;

        foreach (GloveScript HS in gs)
        {
            if (HS.RHbool)
                so.rightHand = HS.currentRH;
            else
                so.leftHand = HS.currentLH;
        }

        foreach (FeetScript FS in FootS)
        {
            if (FS.RFbool)
                so.rightHand = FS.currentRF;
            else
                so.leftHand = FS.currentLF;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            so.health = survival.Health;
            so.hunger = survival.Hunger;
            so.happiness = survival.Happiness;
            so.money = bs.Money;
            so.hat = hs.currentHat;
            so.face = fs.currentFace;

            foreach (GloveScript HS in gs)
            {
                if (HS.RHbool)
                    so.rightHand = HS.currentRH;
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
            SaveManager.Save(so);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            so = SaveManager.Load();
            survival.Health = so.health;
            survival.Hunger = so.hunger;
            survival.Happiness = so.happiness;
            bs.Money = so.money;
            hs.ChangeHat(so.hat);
            fs.ChangeFace(so.face);
            foreach (GloveScript HS in gs)
            {
                if (HS.RHbool)
                    HS.ChangeHand(so.rightHand);
                else
                    HS.ChangeHand(so.leftHand);
            }
            foreach (FeetScript FS in FootS)
            {
                if (FS.RFbool)
                    FS.ChangeFoot(so.rightFoot);
                else
                    FS.ChangeFoot(so.leftFoot);
            }




        }
    }
}
