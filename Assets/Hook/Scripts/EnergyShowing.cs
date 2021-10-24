using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyShowing : MonoBehaviour
{
    
    public int hookE_int;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        hookE_int = GameObject.Find("Player").GetComponent<PlayerController>().hookEnerge;
        this.GetComponent<Text>().text = hookE_int.ToString();
    }
}
