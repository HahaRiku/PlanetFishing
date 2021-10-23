using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    //public float torque;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float turn = Input.GetAxis("Horizontal");
        //rb.AddTorque(transform.up * torque * turn);
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddTorque(40f, 60f, 30f);
        }
    }
}