using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 PlayerPos;

    public GameObject Hook;

    //hookEnerge(�_�l�Ѿl����)
    public int hookEnerge;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = new Vector2(transform.position.x, transform.position.y);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = GetMousePosition();

            ShootHook(pos);
            Debug.Log(pos);
        }
        

    }

    public void ShootHook(Vector3 _mousePos)
    {
        //GameObject temp = Instantiate(Hook);
        //temp.transform.position = _mousePos;

        Instantiate(Hook).GetComponent<Hook>().HookLaunch(_mousePos);
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        mousePos.z = 15;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);//7
        
        return mousePos;
    }
}
