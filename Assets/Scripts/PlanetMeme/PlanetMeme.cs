using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMeme : MonoBehaviour {
    private PlanetMemeType type = PlanetMemeType.Good;
    private PlanetMemeStatus status = PlanetMemeStatus.Wild;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    /// <summary>
    /// 被生成時 要決定成為怎樣的星球
    /// </summary>
    public void OnGenerated(PlanetMemeType _type) {
        type = _type;
        status = PlanetMemeStatus.Wild;

        // Set image or something
    }

    /// <summary>
    /// 鉤到了
    /// </summary>
    public void OnHooked() {
        Debug.Log("Planet " + name + " got hooked.");

        // TODO: Effect


    }

    /// <summary>
    /// 被捕獲成為衛星
    /// </summary>
    public void OnCaptured() {
        Debug.Log("Planet " + name + " become a satellite.");

        status = PlanetMemeStatus.Satellite;
    }
}
