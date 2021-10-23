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

    //hookDispearDis(消失距離)
    public float hookDispearDis;

    private List<PlanetMeme> hookedPlanets = new List<PlanetMeme>();


    // Start is called before the first frame update
    void Start()
    {
        //位移到玩家身上
        transform.position = m_player.transform.position;

        m_rigidbody = GetComponent<Rigidbody>();
        isFlying = true;

        hookLength = 540;
        hookSpeed = 10;
        hookDispearDis = 2f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nowHookLength = (m_player.transform.position - transform.position).sqrMagnitude;
        //繩子
        DrawLine();


        //鉤子鉤東西
        


        //鉤子移動
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
            
            //離玩家太近消失
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


    public void DrawLine()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, this.gameObject.transform.localPosition);
        lineRenderer.SetPosition(1, m_player.gameObject.transform.localPosition);


        lineRenderer.alignment = LineAlignment.View;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Meme" && collider.gameObject.name != m_player.name)
        {
            Debug.Log("鉤子碰撞到了[迷因星球]: " + collider.gameObject.name + " !!!");

            collider.tag = "Untagged";
            collider.gameObject.transform.parent = this.gameObject.transform;
            hookedPlanets.Add(collider.gameObject.GetComponent<PlanetMeme>());
            hookedPlanets[hookedPlanets.Count - 1].OnHooked();
            isFlying = false;
        }
        
    }

    public void HookLaunchTo(Vector3 _force)
    {
        v_force = _force;
        isFlying = true;
    }
}
