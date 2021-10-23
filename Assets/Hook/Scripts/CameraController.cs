using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraMover;
    public Rigidbody cameraMover_rb;

    public float TrunForce;

    // Start is called before the first frame update
    void Start()
    {
        cameraMover_rb = cameraMover.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            cameraMover_rb.AddTorque(0, 0, -TrunForce);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            cameraMover_rb.AddTorque(0, 0, TrunForce);
        }
    }
}
