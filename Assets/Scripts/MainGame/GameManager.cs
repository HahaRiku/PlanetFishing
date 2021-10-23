using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlanetMemeManager planetMemeManager;
    [SerializeField] private GameObject player;

    void Start()
    {
        planetMemeManager.Init(3, 10, 10, player, 3);
        planetMemeManager.StartGenerating();
    }

    void Update()
    {
        
    }
}
