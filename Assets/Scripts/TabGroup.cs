using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;
    private int currentObject;
    [SerializeField]
    private string[] URLText;
    [SerializeField]
    private TMP_Text url;
    public PanelGroup panelGroup;


    private void Start()
    {
        //currentObject = 1;
        /*foreach(GameObject obj in objectsToSwap)
        {
            if (currentObject == 1)
            {
                obj.transform.localScale = new Vector3(1, 1, 0);
                currentObject++;
                Debug.Log(currentObject);
            }
            else
            {
                obj.transform.localScale = new Vector3(0, 0, 0);
                Debug.Log(currentObject);
            }
        }*/
    }
    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void onTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.sprite = tabHover;
        }
    }
    public void OnTabExit(TabButton button)
    {
        ResetTabs();

    }
    public void onTabSelected(TabButton button)
    {
        if(selectedTab != null)
        {
            selectedTab.DeSelect();
        }
        selectedTab = button;
        selectedTab.Select();
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i=0; i<objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
                LeanTween.scale(objectsToSwap[i], new Vector3(1, 1, 0), 0.35f);
                if(URLText.Length < i+1 || URLText[i] == null)
                {
                    Debug.Log("empty");
                }
                else
                {
                    url.text = URLText[i];
                }
            }
            else
            {
                currentObject = i;
                LeanTween.scale(objectsToSwap[i], new Vector3(0, 0, 0), 0.35f).setOnComplete(SetActive);
            }
        }
        if(panelGroup != null)
        {
            panelGroup.SetPageIndex(button.transform.GetSiblingIndex());
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if(selectedTab!=null && button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
        }
    }
    public void SetActive()
    {
        objectsToSwap[currentObject].SetActive(false);
    }
}
