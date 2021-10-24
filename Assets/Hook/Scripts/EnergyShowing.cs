using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyShowing : MonoBehaviour
{
    
    public int hookE_int;

    void Update()
    {
        hookE_int = GameObject.Find("Player").GetComponent<PlayerController>().hookEnerge;
        this.GetComponent<Text>().text = hookE_int.ToString();
    }
}
