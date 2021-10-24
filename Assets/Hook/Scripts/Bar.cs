using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public GameObject barIndex;
    public GameObject barFrame;

    [Range(0f, 1f)]
    public float LiqueNum;

    //是X軸?
    public bool isXbar;

    private Vector3 m_vector3;
    private float x;
    private float y;
    private float z;
    private float xlength;
    private float ylength;

    private float sx;
    private float sy;
    private float sz;

    // Start is called before the first frame update
    void Start()
    {
        LiqueNum = 1;
        m_vector3 = this.transform.position;

        Vector3 length = barFrame.GetComponent<SpriteRenderer>().bounds.size;
        xlength = length.x * transform.lossyScale.x;
        ylength = length.y * transform.lossyScale.y;

        x = barIndex.transform.position.x;
        y = barIndex.transform.position.y;
        z = barIndex.transform.position.z;

        sx = barIndex.transform.localScale.x;
        sy = barIndex.transform.localScale.y;
        sz = barIndex.transform.localScale.z;


    }

    // Update is called once per frame
    void Update()
    {
        if (LiqueNum <= 0)
            LiqueNum = 0;

        if (isXbar)//X
        {
            barIndex.transform.position = new Vector3(x - (((1 - LiqueNum) / 2) * xlength), y, z);
            barIndex.transform.localScale = new Vector3(sx - (1 - LiqueNum), sy, sz);
        }
        else//Y
        {
            barIndex.transform.position = new Vector3(x, y - (((1 - LiqueNum) / 2) * ylength), z);
            barIndex.transform.localScale = new Vector3(sx, sy - (1 - LiqueNum), sz);
        }

    }
}
