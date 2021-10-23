using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject aaa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("wwww");
        }
    }
}
