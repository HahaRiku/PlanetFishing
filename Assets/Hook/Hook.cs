using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameObject m_player;

    public Rigidbody m_rigidbody;
    public Vector3 actTo;

    public bool isFlying;


    public Vector3 v_force;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        isFlying = true;

 

        transform.position = m_player.transform.position;
        force = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFlying)
            m_rigidbody.AddForce(v_force * force);
    }

    public void SetAct(Vector3 _force)
    {
        v_force = _force;
        Debug.Log("11111");
        isFlying = true;
    }
}
