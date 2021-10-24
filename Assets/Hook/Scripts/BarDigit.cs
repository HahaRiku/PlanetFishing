using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDigit : MonoBehaviour
{
    public GameObject energyBlock;

    //能量上限
    public int MaxEnergy;

    //目前能量:讀取外部資料

    //能量剩餘比例
    public float fillLevel;

    //總格子數
    public int totalBlockNum;

    //現格子數
    public int nowBlockNum;

    //應該要的格子數
    public int expectBlockNum;

    //能量格子 遊戲實體
    public GameObject[] blockGameObj = new GameObject[100];

    //用於定位 能量格子生成座標
    public GameObject PosOfEnergy;

    private GameObject m_player;
    private PlayerController m_playerController;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_playerController = m_player.GetComponent<PlayerController>();
        totalBlockNum = 5;
        nowBlockNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fillLevel = GetFillLevel();
        expectBlockNum = (int)fillLevel;

        if (nowBlockNum < expectBlockNum)
            AddEnergy();

    }

    private void AddEnergy()
    {
        //生成能量格子 並推入陣列
        blockGameObj[nowBlockNum] = Instantiate(energyBlock);

        //位移格子
        //blockGameObj[nowBlockNum].transform.position
        nowBlockNum++;
    }

    private float GetFillLevel()
    {
        return (float)(m_playerController.hookEnerge) / (float)(MaxEnergy);
    }
}
