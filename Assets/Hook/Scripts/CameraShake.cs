using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static bool startShake = false; //camera�O�_�}�l�_��

    public static float seconds = 0f; //�_�ʫ�����

    public static bool started = false; //�O�_�w�g�}�l�_��

    public static float quake = 0.2f; //�_�ʫY��

    private Vector3 camPOS; //camera���_�l��m
    
    // Use this for initialization
    void Start()
    {
        camPOS = transform.localPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (startShake)
        {
            transform.localPosition = camPOS + Random.insideUnitSphere * quake;
        }
        
        if (started)
        {
            StartCoroutine(WaitForSecond(seconds));
            started = false;
        }
    }

    /// <summary>
    /// �~���եα���camera�_��
    /// </summary>
    /// <param name="a">�_�ʮɶ�</param>
    /// <param name="b">�_�ʴT��</param>
    public static void ShakeFor(float a, float b)
    {
        // if (startShake)
        // return;
        seconds = a;
        started = true;
        startShake = true;
        quake = b;
    }

    IEnumerator WaitForSecond(float a)
    {
        // camPOS = transform.position;

        yield return new WaitForSeconds(a);
        startShake = false;
        transform.localPosition = camPOS;
    }
}
