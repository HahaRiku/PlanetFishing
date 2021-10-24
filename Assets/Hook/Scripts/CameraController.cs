using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody camera_rb;

    public float TrunForce;

    // Start is called before the first frame update
    void Start()
    {
        camera_rb = this.transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            camera_rb.AddTorque(0, 0, -TrunForce);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            camera_rb.AddTorque(0, 0, TrunForce);
        }
    }

    //public void Shacked()
    //{
        
    //}
}
