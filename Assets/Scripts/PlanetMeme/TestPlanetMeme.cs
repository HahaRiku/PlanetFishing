using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlanetMeme : MonoBehaviour {
    [SerializeField] private PlanetMemeManager planetMemeManager = null;
    [SerializeField] private bool startGenerating = false;
    
    // Start is called before the first frame update
    void Start() {
        planetMemeManager.Init(3, 10, 10, gameObject, 3);
    }

    // Update is called once per frame
    void Update() {
        if(startGenerating) {
            startGenerating = false;
            planetMemeManager.StartGenerating();
        }
    }
}
