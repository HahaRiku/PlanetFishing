using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlanetMemeManager planetMemeManager;
    [SerializeField] private GameObject player;
    [SerializeField] private AnimationMgr animatorMgr;
    [SerializeField] private ResultView resultView;
    [SerializeField] private GameObject energyView;

    private PlayerController playerController;

    private static GameManager _instance; //單例模式
    public static GameManager Instance
    {
        get { return _instance; }
    }

    public Action<PlanetMemeType, string> OnHookTypeCallback;
    public Action EndGameCallback;

    private int hookedMemeCount;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this; //設定單例
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        BgmManager.Instance.PlayBgmClip("遊戲內bgm");
        planetMemeManager.Init(5, 30, 20, player, 0.5f);
        planetMemeManager.StartGenerating();

        playerController = player.GetComponent<PlayerController>();
        OnHookTypeCallback = OnHooked;
        EndGameCallback = CheckEndGame;

        energyView.SetActive(true);
        hookedMemeCount = 0;
    }

    private void OnHooked(PlanetMemeType type, string name)
    {
        if (type == PlanetMemeType.Bad)
        {
            ShowAnimation(name);
        }
        else
        {
            ++hookedMemeCount;
        }
    }

    private void ShowAnimation(string name)
    {
        animatorMgr.ShowVideo(name);
    }

    private void CheckEndGame()
    {
        if (playerController.hookEnerge < 1)
        {
            energyView.SetActive(false);
            resultView.OnResult(hookedMemeCount);
        }
    }
}
