using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameObject m_player;
    public Rigidbody m_rigidbody;

    public bool isFlying;
    public Vector3 v_force;
    public float nowHookLength;

    //hookLength(鉤子長度)
    public float hookLength;

    //hookSpeed(出鉤速度)
    public float hookSpeed;



    // Start is called before the first frame update
    void Start()
    {
        //位移到玩家身上
        transform.position = m_player.transform.position;

        m_rigidbody = GetComponent<Rigidbody>();
        isFlying = true;

        hookLength = 80;
        hookSpeed = 10;
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nowHookLength = (m_player.transform.position - transform.position).sqrMagnitude;

        if (isFlying && nowHookLength < hookLength)
            m_rigidbody.AddForce(v_force * hookSpeed);
        else
        {
            m_rigidbody.velocity = Vector3.zero;
            m_rigidbody.angularVelocity = Vector3.zero;
        }
    }

    public void HookLaunch(Vector3 _force)
    {
        v_force = _force;
        isFlying = true;
    }
}
