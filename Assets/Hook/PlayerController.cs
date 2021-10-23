using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 PlayerPos2D;

    public GameObject Aobj;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos2D = new Vector2(0, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = GetMousePosition();
            pos.z = 20;
            pos = Camera.main.ScreenToWorldPoint(pos);
            ShootHook(pos);
            Debug.Log(pos);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("wwww");
        }
    }

    public void ShootHook(Vector3 _mousePos)
    {
        GameObject temp = Instantiate(Aobj);
        temp.transform.position = _mousePos;

    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

        return mousePos;
    }
}
