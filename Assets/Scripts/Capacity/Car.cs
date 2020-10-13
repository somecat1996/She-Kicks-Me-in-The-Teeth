using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Animator anim;

    public bool drive;
    public bool save;
    public bool key;

    [Header("技能CD")]
    public float CD;
    private float startCD;

    [Header("开车所需消耗的耐力值")]
    public float staminaValue;

    private bool haoWan;

    private void Start()
    {
        //开车的布尔值
        drive = false;
        save=false;

        //时间重置
        startCD = CD;
    }
    private void Update()
    {
        //传值
        haoWan = GetComponent<Stamina>().HaoWan;

        //技能冷却计算
        if (!save&&CD>=0)
        {
            CD -= Time.deltaTime;
        }
        else if (CD<0)
        {
            //CD重置
            CD = startCD;
            
            //防止CD开始计算
            save = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            key = true;
        }

        if (key&&save)
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
            save = false;
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
        }
    }
}
