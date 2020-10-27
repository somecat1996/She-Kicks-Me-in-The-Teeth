using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameController gameController;

    public Animator anim;
    public GameObject body;

    public bool drive;
    public bool save;
    public bool key;

    public RandomPlayAudio randomPlayAudio;

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

        if (!gameController.pause && !gameController.end && key&&!haoWan)
        {
            drive = true;
            //消耗耐力值
            GetComponent<Stamina>().ReduceStaminaValue(staminaValue);
            //开启动画
            anim.SetBool("Drive", true);
            //关闭角色可以被伤害判定
            body.SetActive(false);
        }

        if (haoWan)
        {
            drive = false;
            key = false;
            //开启角色可以被伤害判定
            body.SetActive(true);
            anim.SetBool("Drive", false);
        }      
    }
    //开车冲刺
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block"&&drive)
        {
            Destroy(collision.gameObject);
            randomPlayAudio.RandomPlay();
        }
        if (collision.tag == "Enemy" && drive)
        {
            Destroy(collision.gameObject);
            gameController.OnDefeatEnemy(value0);
            randomPlayAudio.RandomPlay();
        }
        if (collision.tag == "Bullet" && drive)
        {
            Destroy(collision.gameObject);
            randomPlayAudio.RandomPlay();
        }
    }
}
