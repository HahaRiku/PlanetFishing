using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager : MonoBehaviour {
    [SerializeField] private GameObject meteoritePrefab;

    // Start is called before the first frame update
    void Start() {
        StartGenerating();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void StartGenerating() {
        GenerateMeteorite();
    }

    private void GenerateMeteorite() {
        Instantiate(meteoritePrefab, new Vector3(Random.Range(-40, 40), Random.Range(-16, 16), 10), Quaternion.identity);
        Invoke("GenerateMeteorite", 3f);
    }
}
