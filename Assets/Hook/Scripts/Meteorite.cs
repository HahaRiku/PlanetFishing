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

    //���ͫ�V���a��V(+- Seta ��)���L�h
    // Start is called before the first frame update
    void Start()
    {
        //Seta ��
        Seta = 35 * Mathf.Deg2Rad;

        //30% ���g
        float isEveil = Random.Range(0, 1);
        if(isEveil <= 0.3)
            Seta = 0 * Mathf.Deg2Rad;

        //�ѤU�s�b�ɶ�
        lifeTime = 10;

        //�缾�a���V�q
        flyTo = -this.transform.position + m_player.transform.position;
        flyTo.z = 0;
        flyTo = flyTo.normalized;

        //�T�����+- Seta ��
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

        //�����a�ӻ����� (�B�Ӥ[)
        if (radius > 1000 && lifeTime<0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //�Y�k�ۯ{�쪱�a
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
