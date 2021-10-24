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

    //isHooked(勾住中?)
    public bool isHooked;

    //玩家位移啟用?
    public bool isDisplacementFunc;
    public bool player_flying;

    private Transform m_parent;

    private List<PlanetMeme> hookedPlanets = new List<PlanetMeme>();


    // Start is called before the first frame update
    void Start()
    {
        m_parent = this.transform.parent;
        //位移到玩家身上
        //transform.position = m_player.transform.position;
        transform.position = m_parent.transform.position;

        m_rigidbody = GetComponent<Rigidbody>();
        isFlying = true;

        hookLength = 540;
        hookSpeed = 15;
        hookDispearDis = 3.5f;
        isHooked = false;

        isDisplacementFunc = true;
        player_flying = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //目前繩子長度
        nowHookLength = (m_parent.transform.position - transform.position).sqrMagnitude;

        //畫繩子
        DrawLine();

        //鉤子移動
        if (isFlying && nowHookLength < hookLength)
        {
            m_rigidbody.AddForce((v_force - m_parent.transform.position) * hookSpeed);
        }
        else
        {
            m_rigidbody.velocity = Vector3.zero;
            m_rigidbody.angularVelocity = Vector3.zero;
            isFlying = false;
        }

        if (!isFlying)
        {
            //拉回來的力
            v_force = (m_parent.transform.position - transform.position) * hookSpeed;
            
            //拉回來
            m_rigidbody.AddForce(v_force * 15f);
            
            //離玩家太近消失
            if (nowHookLength < hookDispearDis)
            {
                if (hookedPlanets.Count > 0)
                {
                    //收回星球會與迷因音效重疊，先拔掉
                    //AudioManagerScript.Instance.CoverPlayAudioClip("收回星球");
                }
                else
                {
                    AudioManagerScript.Instance.CoverPlayAudioClip("伸出與收回抓子");
                }

                for (int i = 0; i < hookedPlanets.Count; i++) {
                    hookedPlanets[i].transform.parent = transform.parent;
                    hookedPlanets[i].OnCaptured();
                }
                Destroy(this.gameObject, 0.01f);
                player_flying = false;

                GameManager.Instance.EndGameCallback?.Invoke();
            }
        }

        if (isDisplacementFunc)
        {
            if (player_flying)
            {
                //反作用位移力nowHookLength
                var forceVec = -1 * v_force;//(v_force - m_parent.transform.position);
                forceVec.z = 0f;
                forceVec = forceVec.normalized * hookSpeed;

                m_parent.GetComponent<Rigidbody>().AddForce(15f * forceVec);
                
            }
        }
    }

    //畫鉤子的線(鎖鏈)
    public void DrawLine()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, this.gameObject.transform.position);
        lineRenderer.SetPosition(1, m_parent.gameObject.transform.localPosition);


        lineRenderer.alignment = LineAlignment.View;
    }

    //鉤子碰到時觸發
    public void OnTriggerEnter(Collider collider)
    {
        if (isHooked)
        {
            player_flying = true;
            return;
        }

        if(collider.tag == "Meme" && collider.gameObject.name != m_parent.name )
        {
            isFlying = false;// 正在回拉
            isHooked = true;// 正在勾住
            Debug.Log("鉤子碰撞到了[迷因星球]: " + collider.gameObject.name + " !!!");
            AudioManagerScript.Instance.CoverPlayAudioClip("抓住星球");

            collider.tag = "Untagged";
            collider.gameObject.transform.parent = this.gameObject.transform;
            hookedPlanets.Add(collider.gameObject.GetComponent<PlanetMeme>());
            hookedPlanets[hookedPlanets.Count - 1].OnHooked();
            
        }
        
    }

    public void HookLaunchTo(Vector3 _force)
    {
        v_force = _force;
        isFlying = true;
    }
}
//player 家鋼體