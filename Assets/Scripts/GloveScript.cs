using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveScript : MonoBehaviour
{
    public Sprite[] righthand;
    public Sprite[] lefthand;
    public int currentRH;
    public int currentLH;
    private int randomInt;
    private SpriteRenderer sr;
    public bool RHbool;
    public SaveObject so;
    public ClickerScript cs;
    public GloveBuyScript gbs;
    private float RGcurrentIncrement;
    private float LGcurrentIncrement;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeGlove(int glove)
    {
        if (RHbool)
        {
            sr.sprite = righthand[glove];
            currentRH = glove;
            AddIncrement(glove);
        }
        else
        {
            sr.sprite = lefthand[glove];
            currentLH = glove;
            AddIncrement(glove);
        }
    }

    public void AddIncrement(int glove)
    {
        if (RHbool)
        {
            if (gbs.RGaddedIncrement[glove] > RGcurrentIncrement)
            {
                cs.Upgrade(gbs.RGaddedIncrement[glove], RGcurrentIncrement, "RG");
                RGcurrentIncrement = gbs.RGaddedIncrement[glove];
            }
        }
        else
        {
            if (gbs.LGaddedIncrement[glove] > LGcurrentIncrement)
            {
                cs.Upgrade(gbs.LGaddedIncrement[glove], LGcurrentIncrement, "LG");
                LGcurrentIncrement = gbs.LGaddedIncrement[glove];
            }
        }
    }


    public void Buy()
    {

    }
}
