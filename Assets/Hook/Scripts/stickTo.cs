using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickTo : MonoBehaviour
{
    public GameObject targetObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = targetObj.transform.position;
    }
}
