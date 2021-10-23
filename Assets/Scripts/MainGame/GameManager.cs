using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlanetMemeManager planetMemeManager;
    [SerializeField] private GameObject player;

    void Start()
    {
        planetMemeManager.Init(5, 30, 20, player, 0.5f);
        planetMemeManager.StartGenerating();
    }

    void Update()
    {
        
    }
}
