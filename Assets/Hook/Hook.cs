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

    //hookLength(�_�l����)
    public float hookLength;

    //hookSpeed(�X�_�t��)
    public float hookSpeed;

    //hookDispearDis(�����Z��)
    public float hookDispearDis;


    // Start is called before the first frame update
    void Start()
    {
        //�첾�쪱�a���W
        transform.position = m_player.transform.position;

        m_rigidbody = GetComponent<Rigidbody>();
        isFlying = true;

        hookLength = 80;
        hookSpeed = 10;
        hookDispearDis = 2f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nowHookLength = (m_player.transform.position - transform.position).sqrMagnitude;

        //�_�l�_�F��
        


        //�_�l����
        if (isFlying && nowHookLength < hookLength)
            m_rigidbody.AddForce(v_force * hookSpeed);
        else
        {
            m_rigidbody.velocity = Vector3.zero;
            m_rigidbody.angularVelocity = Vector3.zero;
            isFlying = false;
            v_force = (m_player.transform.position - transform.position) * hookSpeed;
        }

        if (!isFlying)
        {
            m_rigidbody.AddForce(v_force * hookSpeed);
            
            //�����a�Ӫ����
            if (nowHookLength < hookDispearDis)
            {
                Destroy(this.gameObject, 0.01f);
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Meme" && collider.gameObject.name != m_player.name)
        {
            Debug.Log("�_�l�I����F[�g�]�P�y]: " + collider.gameObject.name + " !!!");

            collider.tag = "Untagged";
            collider.gameObject.transform.parent = this.gameObject.transform;

        }
        
    }

    public void HookLaunchTo(Vector3 _force)
    {
        v_force = _force;
        isFlying = true;
    }
}
