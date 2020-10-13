using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameController gameController;

    public Animator anim;

    public bool drive;
    public bool save;
    public bool key;


    [Header("开车所需消耗的耐力值")]
    public float staminaValue;

    [Header("撞击路人得到牙齿量")]
    public int value0;

    private bool haoWan;

    private void Start()
    {
        //开车的布尔值
        drive = false;
    }
    private void Update()
    {
        //传值
        haoWan = GetComponent<Stamina>().HaoWan;

        if (Input.GetMouseButtonDown(0))
        {
            key = true;
        }

        if (key&&!haoWan)
        {
            drive = true;
            GetComponent<Stamina>().ReduceStaminaValue(staminaValue);

            anim.SetBool("Drive", true);
        }

        Debug.Log(haoWan);
        if (haoWan)
        {
            drive = false;
            key = false;
            anim.SetBool("Drive", false);
        }      
    }
    //开车冲刺
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block"&&drive)
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Enemy" && drive)
        {
            Destroy(collision.gameObject);
            gameController.OnDefeatEnemy(value0);
        }
    }
}
