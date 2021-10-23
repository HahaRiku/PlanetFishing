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
    /// �Q�ͦ��� �n�M�w������˪��P�y
    /// </summary>
    public void OnGenerated(PlanetMemeType _type) {
        type = _type;
        status = PlanetMemeStatus.Wild;

        // Set image or something
    }

    /// <summary>
    /// �_��F
    /// </summary>
    public void OnHooked() {
        Debug.Log("Planet " + name + " got hooked.");

        // TODO: Effect


    }

    /// <summary>
    /// �Q���򦨬��ìP
    /// </summary>
    public void OnCaptured() {
        Debug.Log("Planet " + name + " become a satellite.");

        status = PlanetMemeStatus.Satellite;
    }
}
