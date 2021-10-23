using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingRoute : MonoBehaviour {
    private List<GameObject> planetsInRoute = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ReceiveNewPlanet(GameObject planet) {
        planet.transform.parent = transform;
        planetsInRoute.Add(planet);
    }
}
