using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMemeManager : MonoBehaviour {
    [SerializeField] private GameObject PlanetMemePrefab = null;
    [SerializeField] private Sprite[] PlanetsSprite;
    [SerializeField] private CirclingRoute circlingRoute = null;

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
    /// 初始化迷因星球生成設定
    /// </summary>
    /// <param name="_spaceScale"> 多少距離內隨機位置生成 </param>
    /// <param name="_memeNumMax"> 場上最大數量 </param>
    /// <param name="_playerObj"> 玩家位置 </param>
    /// <param name="_generateInterval"> 生成的時間間隔 </param>
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
        // x^2 + y^2 = d^2 -> random 小於d^2的數開根號給x用，y再後續得出
        float random_Pow2ofX = Random.Range(0.0f, Mathf.Pow(distance, 2));
        float x = (Random.Range(0, 10) > 4 ? 1 : -1) * Mathf.Sqrt(random_Pow2ofX);
        float y = Mathf.Sqrt(Mathf.Pow(distance, 2) - random_Pow2ofX);  //因為不轉視角 y先都用正的
        GameObject planet = Instantiate(PlanetMemePrefab, new Vector3(playerObj.transform.localPosition.x + x, playerObj.transform.localPosition.y + y, 0), Quaternion.Euler(0, 0, Random.Range(0, 359)));
        PlanetMeme planetMeme = planet.GetComponent<PlanetMeme>();
        PlanetMemeType type = Random.Range(0, 10) > 4 ? PlanetMemeType.Good : PlanetMemeType.Bad;
        planetMeme.OnGenerated(type, PlanetsSprite[Random.Range(0, PlanetsSprite.Length)], this);

        planetsInGame.Add(planet);

        if(planetsInGame.Count < memeNumMax)
            Invoke("GenerateNewPlanet", generateInterval);
    }

    /// <summary>
    /// 星球被抓到了 丟去給circlingRoute管理(成為衛星)
    /// </summary>
    /// <param name="planet"></param>
    public void OnPlanetCaptured(GameObject planet) {
        planetsInGame.Remove(planet);
        circlingRoute.ReceiveNewPlanet(planet);
    }
}

public enum PlanetMemeType {
    Good,
    Bad
}

public enum PlanetMemeStatus {
    Wild,   // 等待被抓
    Satellite   // 變成了衛星
}