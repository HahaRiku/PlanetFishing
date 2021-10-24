using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDigit : MonoBehaviour
{
    public GameObject energyBlock;

    //��q�W��
    public int MaxEnergy;

    //�ثe��q:Ū���~�����

    //��q�Ѿl���
    public float fillLevel;

    //�`��l��
    public int totalBlockNum;

    //�{��l��
    public int nowBlockNum;

    //���ӭn����l��
    public int expectBlockNum;

    //��q��l �C������
    public GameObject[] blockGameObj = new GameObject[100];

    //�Ω�w�� ��q��l�ͦ��y��
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
        //�ͦ���q��l �ñ��J�}�C
        blockGameObj[nowBlockNum] = Instantiate(energyBlock);

        //�첾��l
        //blockGameObj[nowBlockNum].transform.position
        nowBlockNum++;
    }

    private float GetFillLevel()
    {
        return (float)(m_playerController.hookEnerge) / (float)(MaxEnergy);
    }
}
