using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlanetMeme : MonoBehaviour {
    [SerializeField] private PlanetMemeManager planetMemeManager = null;
    [SerializeField] private bool startGenerating = false;
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start() {
        planetMemeManager.Init(3, 10, 10, player, 3);
    }

    // Update is called once per frame
    void Update() {
        if(startGenerating) {
            startGenerating = false;
            planetMemeManager.StartGenerating();
        }
    }
}
