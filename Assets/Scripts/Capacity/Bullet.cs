using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("箭消失的时间")]
    public float timer;
    [Tooltip("箭的伤害值")]
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, timer);
        
    }
    void OnTriggerEnter2D(Collider2D collision)//敌人进入范围调用
    {
        if (collision.tag == "Player")
        {
            //Destroy(gameObject);
        }

    }
}
