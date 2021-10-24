using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageMgr : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup MenuBG;
    
    [SerializeField]
    private GameObject controlPage;

    void Start()
    {
        BgmManager.Instance.PlayBgmClip("MenuBGM");
    }

    public void ClickToControl()
    {
        controlPage.SetActive(true);
        MenuBG.alpha = 0;
        MenuBG.interactable = false;
        MenuBG.blocksRaycasts = false;
    }

    public void ClickBack()
    {
        controlPage.SetActive(false);
        MenuBG.alpha = 1;
        MenuBG.interactable = true;
        MenuBG.blocksRaycasts = true;
    }
}
