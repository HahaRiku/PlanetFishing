using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMemeManager : MonoBehaviour {
    [SerializeField] private GameObject PlanetMemePrefab = null;

    //Generating paramaters
    private float spaceScale_min;
    private float spaceScale_max;
    private int memeNumMax = 10;
    private GameObject playerObj;
    private float generateInterval;

    private List<GameObject> planetsInGame = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    /// <summary>
    /// ��l�ưg�]�P�y�ͦ��]�w
    /// </summary>
    /// <param name="_spaceScale"> �h�ֶZ�����H����m�ͦ� </param>
    /// <param name="_memeNumMax"> ���W�̤j�ƶq </param>
    /// <param name="_playerObj"> ���a��m </param>
    /// <param name="_generateInterval"> �ͦ����ɶ����j </param>
    public void Init(float _spaceScale_min, float _spaceScale_max, int _memeNumMax, GameObject _playerObj, float _generateInterval) {
        spaceScale_min = _spaceScale_min;
        spaceScale_max = _spaceScale_max;
        memeNumMax = _memeNumMax;
        playerObj = _playerObj;
        generateInterval = _generateInterval;
    }

    public void StartGenerating() {
        GenerateNewPlanet();
    }

    private void GenerateNewPlanet() {

        float distance = Random.Range(spaceScale_min, spaceScale_max);
        // x^2 + y^2 = d^2 -> random �p��d^2���ƶ}�ڸ���x�ΡAy�A����o�X
        float random_Pow2ofX = Random.Range(0.0f, Mathf.Pow(distance, 2));
        float x = (Random.Range(0, 10) > 4 ? 1 : -1) * Mathf.Sqrt(random_Pow2ofX);
        float y = Mathf.Sqrt(Mathf.Pow(distance, 2) - random_Pow2ofX);  //�]��������� y�����Υ���
        GameObject planet = Instantiate(PlanetMemePrefab, new Vector3(playerObj.transform.localPosition.x + x, playerObj.transform.localPosition.y + y, 0), Quaternion.identity);

        planetsInGame.Add(planet);

        if(planetsInGame.Count < memeNumMax)
            Invoke("GenerateNewPlanet", generateInterval);
    }
}

public enum PlanetMemeType {
    Good,
    Bad
}

public enum PlanetMemeStatus {
    Wild,   // ���ݳQ��
    Satellite   // �ܦ��F�ìP
}