using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingRoute : MonoBehaviour {
    private const float SATELLITE_DISTANCE = 0.1f;
    private List<GameObject> planetsInRoute = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void ReceiveNewPlanet(GameObject planet) {
        planet.transform.parent = transform;
        Vector2 direction = new Vector2(planet.transform.localPosition.x, planet.transform.localPosition.y);
        Vector2 newDirection = direction * (SATELLITE_DISTANCE / direction.magnitude);
        planet.transform.localPosition = new Vector3(newDirection.x, newDirection.y, planet.transform.localPosition.z);
        planet.transform.localScale *= 0.3f;
        planetsInRoute.Add(planet);
    }
}
