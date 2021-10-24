using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 PlayerPos;

    public GameObject Hook;

    //hookEnerge(鉤子剩餘次數)
    public int hookEnerge;

    public float hookColdown;
    public float hookColdownMax;

    public GameObject tempObj;

    public float Delta;

    [SerializeField] private Sprite rightPlayer;
    [SerializeField] private Sprite leftPlayer;
    [SerializeField] private SpriteRenderer playerSR;
    [SerializeField] private GameObject UFO;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = new Vector2(transform.position.x, transform.position.y);
        hookColdownMax = 0.75f;
        hookColdown = hookColdownMax;

        hookEnerge = 15;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        hookColdown -= Time.deltaTime;

        //[左鍵] 發射
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && hookColdown <= 0.0f)
        {
            Vector3 pos_screen = GetMousePosition_Screen();

            if(pos_screen.x >= Screen.width / 2) {
                playerSR.sprite = rightPlayer;
                UFO.transform.localScale = new Vector3(Mathf.Abs(UFO.transform.localScale.x), UFO.transform.localScale.y, UFO.transform.localScale.z);
            }
            else {
                playerSR.sprite = leftPlayer;
                UFO.transform.localScale = new Vector3(Mathf.Abs(UFO.transform.localScale.x) * -1, UFO.transform.localScale.y, UFO.transform.localScale.z);
            }

            Vector3 pos = ScreenPos2World(pos_screen);

            ShootHook(pos);
            //Debug.Log(pos);

            hookColdown = hookColdownMax;
        }

        //[右鍵] 緊急切斷
        if (Input.GetMouseButton(1) && hookColdown <= 0.0f)
        {
            var temp = GameObject.Find("Hook(Clone)");
            if (temp != null)
            {
                
                Destroy(temp.gameObject);
            }

            hookColdown = 0;
        }

    }

    public void ShootHook(Vector3 _mousePos)
    {
        //GameObject temp = Instantiate(Hook);
        //temp.transform.position = _mousePos;
        if (hookEnerge <= 0)
        {
            return;
        }

        tempObj = Instantiate(Hook);
        tempObj.GetComponent<Hook>().HookLaunchTo(_mousePos);
        tempObj.gameObject.transform.parent = this.transform;

        hookEnerge--;
    }

    public Vector3 GetMousePosition_Screen()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        return mousePos;
    }

    public Vector3 ScreenPos2World(Vector3 mousePos) {
        mousePos.z = 15;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);//7

        return mousePos;
    }
}
