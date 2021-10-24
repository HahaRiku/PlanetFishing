using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDigit : MonoBehaviour
{
    //��l�ҪO
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
    public GameObject PosOfRadar;

    private float lengtgOfBlock;//��l��
    private GameObject m_player;
    private PlayerController m_playerController;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_playerController = m_player.GetComponent<PlayerController>();
        lengtgOfBlock = energyBlock.GetComponent<SpriteRenderer>().bounds.size.y * transform.lossyScale.y;

        //MaxEnergy = m_playerController.hookMaxma;
        MaxEnergy = GameObject.Find("Player").GetComponent<PlayerController>().hookMaxma;

        totalBlockNum = 5;
        nowBlockNum = 0;

    }

    // Update is called once per frame
    void Update()
    {
        fillLevel = GetFillLevel();
        expectBlockNum = (int)(fillLevel * totalBlockNum);

        if (nowBlockNum < expectBlockNum)
            AddEnergy();

        if (nowBlockNum > expectBlockNum)
            SubEnergy();

    }

    private void AddEnergy()
    {
        //�ͦ���q��l �ñ��J�}�C
        blockGameObj[nowBlockNum] = Instantiate(energyBlock);

        //�첾��l
        blockGameObj[nowBlockNum].transform.position = PosOfEnergy.transform.position + (PosOfEnergy.transform.position - PosOfRadar.transform.position).normalized * lengtgOfBlock * nowBlockNum;//new Vector3(0f, lengtgOfBlock, 0f) * nowBlockNum;

        blockGameObj[nowBlockNum].transform.rotation = this.transform.rotation;

        blockGameObj[nowBlockNum].transform.parent = PosOfEnergy.transform;

        nowBlockNum++;
    }

    private void SubEnergy()
    {
        //�P����q��l �ñ��X�}�C
        Destroy(blockGameObj[nowBlockNum].gameObject);
        blockGameObj[nowBlockNum] = null;
        nowBlockNum--;
    }
    private float GetFillLevel()
    {
        return (float)(m_playerController.hookEnerge) / (float)(MaxEnergy);
    }
}
