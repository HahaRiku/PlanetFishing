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

    public Action<PlanetMemeType, int> OnHookTypeCallback;
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

    private void OnHooked(PlanetMemeType type, int num)
    {
        if (type == PlanetMemeType.Bad)
        {
            ShowAnimation(num);
        }
        else
        {
            ++hookedMemeCount;
        }
    }

    private void ShowAnimation(int num)
    {
        switch (num)
        {
            case 0:
                animatorMgr.Show統神跌倒();
                break;
            case 1:
                animatorMgr.Show冰冰姐();
                break;
            case 2:
                animatorMgr.Show瑞克搖();
                break;
            case 3:
                animatorMgr.Show蹦蹦姊();
                break;
            default:
                animatorMgr.Show統神走路();
                break;
        }
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
