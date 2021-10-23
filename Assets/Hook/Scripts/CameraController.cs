using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraMover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            cameraMover.transform.Rotate(0, 0, -3);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            cameraMover.transform.Rotate(0, 0, 3);
        }
    }
}
