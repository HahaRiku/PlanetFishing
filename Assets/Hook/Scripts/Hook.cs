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

    //isHooked(�Ħ�?)
    public bool isHooked;

    private Transform m_parent;

    private List<PlanetMeme> hookedPlanets = new List<PlanetMeme>();


    // Start is called before the first frame update
    void Start()
    {
        m_parent = this.transform.parent;
        //�첾�쪱�a���W
        //transform.position = m_player.transform.position;
        transform.position = m_parent.transform.position;

        m_rigidbody = GetComponent<Rigidbody>();
        isFlying = true;

        hookLength = 540;
        hookSpeed = 10;
        hookDispearDis = 2f;
        isHooked = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�ثe÷�l����
        nowHookLength = (m_parent.transform.position - transform.position).sqrMagnitude;

        //�e÷�l
        DrawLine();

        //�_�l����
        if (isFlying && nowHookLength < hookLength)
            m_rigidbody.AddForce((v_force-m_parent.transform.position) * hookSpeed);
        else
        {
            m_rigidbody.velocity = Vector3.zero;
            m_rigidbody.angularVelocity = Vector3.zero;
            isFlying = false;
            v_force = (m_parent.transform.position - transform.position) * hookSpeed;
        }

        if (!isFlying)
        {
            m_rigidbody.AddForce(v_force * hookSpeed);
            
            //�����a�Ӫ����
            if (nowHookLength < hookDispearDis)
            {
                for(int i = 0; i < hookedPlanets.Count; i++) {
                    hookedPlanets[i].transform.parent = transform.parent;
                    hookedPlanets[i].OnCaptured();
                }
                Destroy(this.gameObject, 0.01f);
            }
        }
    }

    //�e�_�l���u(����)
    public void DrawLine()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, this.gameObject.transform.position);
        lineRenderer.SetPosition(1, m_parent.gameObject.transform.localPosition);


        lineRenderer.alignment = LineAlignment.View;
    }

    //�_�l�I���Ĳ�o
    public void OnTriggerEnter(Collider collider)
    {
        if (isHooked)
        {
            return;
        }

        if(collider.tag == "Meme" && collider.gameObject.name != m_parent.name )
        {
            Debug.Log("�_�l�I����F[�g�]�P�y]: " + collider.gameObject.name + " !!!");

            collider.tag = "Untagged";
            collider.gameObject.transform.parent = this.gameObject.transform;
            hookedPlanets.Add(collider.gameObject.GetComponent<PlanetMeme>());
            hookedPlanets[hookedPlanets.Count - 1].OnHooked();
            isFlying = false;// ���b�^��
            isHooked = true;// ���b�Ħ�
        }
        
    }

    public void HookLaunchTo(Vector3 _force)
    {
        v_force = _force;
        isFlying = true;
    }
}
