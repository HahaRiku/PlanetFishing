using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickTo : MonoBehaviour
{
    public GameObject targetObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = targetObj.transform.position;
        //this.gameObject.transform.rotation = targetObj.transform.rotation;
        this.gameObject.transform.rotation = new Quaternion(targetObj.transform.rotation.x, targetObj.transform.rotation.y ,0f,0f);

    }
}
