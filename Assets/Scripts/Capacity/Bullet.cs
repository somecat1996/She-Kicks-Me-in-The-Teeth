using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("子弹消失的时间")]
    public float timer;
    [Header("子弹的速度")]
    public float speed;
    private float addSpeed;
    public Rigidbody2D rb;

    private TrackController trackController;
    private Animator anim;

    void Start()
    {
        trackController = GameObject.FindGameObjectWithTag("TrackController").GetComponent<TrackController>();

        anim = GetComponent<Animator>();

        Destroy(gameObject, timer); 
        if (this.transform.position.y > -2.08f)
        {
            this.gameObject.layer = LayerMask.NameToLayer("FirstTrack");
        }
        else if (this.transform.position.y < -2.08f)
        {
            this.gameObject.layer = LayerMask.NameToLayer("ThirdTrack");
        }
        else
        {
            this.gameObject.layer = LayerMask.NameToLayer("SecondTrack");
        }
    }

    private void Update()
    {
        if (!(GameObject.Find("Girl") == null))
        {
            anim.SetTrigger("Sleeping");
            //传跑道速度值
            addSpeed = trackController.velocity;
            //设置子弹速度
            rb.velocity = transform.right *  - addSpeed ;
            //Debug.Log(addSpeed);
        }
        else
        {
            //传跑道速度值
            addSpeed = trackController.velocity;
            //设置子弹速度
            rb.velocity = transform.right * (speed - addSpeed);// speed;//Debug.Log(speed - addSpeed);
        }
    }

    //void OnTriggerEnter2D(Collider2D collision)//敌人进入范围调用
    //{
    //    if (collision.tag == "Player")
    //    {
    //        //Destroy(gameObject);
    //    }
    //}
}
