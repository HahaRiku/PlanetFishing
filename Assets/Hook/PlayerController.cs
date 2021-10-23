using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 PlayerPos;

    public GameObject Hook;

    //hookEnerge(¹_¤l³Ñ¾l¦¸¼Æ)
    public int hookEnerge;

    public float hookColdown;

    public float Delta;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = new Vector2(transform.position.x, transform.position.y);
        hookColdown = Time.deltaTime;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        hookColdown -= Time.deltaTime;
        if (Input.GetMouseButton(0) && hookColdown <= 0.0f)
        {
            Vector3 pos = GetMousePosition();

            ShootHook(pos);
            Debug.Log(pos);

            hookColdown = Time.deltaTime;
        }


    }

    public void ShootHook(Vector3 _mousePos)
    {
        //GameObject temp = Instantiate(Hook);
        //temp.transform.position = _mousePos;

        Instantiate(Hook).GetComponent<Hook>().HookLaunchTo(_mousePos);
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        mousePos.z = 15;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);//7
        
        return mousePos;
    }
}
