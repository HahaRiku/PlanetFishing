using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public GameObject m_player;
    private Vector3 flyTo;
    public float Seta;

    private float ramdomSita;
    private float lifeTime;

    //產生後向玩家方向(+- Seta 度)飛過去
    // Start is called before the first frame update
    void Start()
    {
        //Seta 度
        Seta = 35 * Mathf.Deg2Rad;

        //30% 直射
        float isEveil = Random.Range(0, 1);
        if(isEveil <= 0.3)
            Seta = 0 * Mathf.Deg2Rad;

        //剩下存在時間
        lifeTime = 10;

        //對玩家飛向量
        flyTo = -this.transform.position + m_player.transform.position;
        flyTo.z = 0;
        flyTo = flyTo.normalized;

        //三角函數+- Seta 度
        ramdomSita = Random.Range(-Seta, Seta);
        float sinSita = Mathf.Sin(ramdomSita);
        float cosSita = Mathf.Cos(ramdomSita);

        float trsferX = (flyTo.x * cosSita) - (flyTo.y * sinSita);
        float trsferY = (flyTo.x * sinSita) + (flyTo.y * cosSita);

        flyTo = new Vector3(trsferX, trsferY, 0);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;

        float radius = (this.transform.position - GameObject.Find("Player").transform.position).sqrMagnitude;
        this.GetComponent<Rigidbody>().AddForce(10f * flyTo);

        //離玩家太遠消失 (且太久)
        if (radius > 1000 && lifeTime<0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //若隕石砸到玩家
        if(collision.gameObject.name == "Player")
        {
            GameObject m_camera = GameObject.Find("Player").transform.GetChild(0).gameObject;
            if(m_camera.name == "Main Camera")
            {
                //m_camera.GetComponent<CameraController>().Shacked();
                CameraShake.ShakeFor(0.75f, 2f);
            }
        }
    }
}
