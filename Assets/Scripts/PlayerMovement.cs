using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [Header("人物上下移动距离")]
    public float Y;
    [Header("切换赛道速度")]
    public float move;

    private Vector3 dest;
    private Vector3 v;

    [Header("碰撞判断框")]
    public GameObject COLL;
    [Header("攻击判断框")]
    public GameObject ATK;

    // Start is called before the first frame update
    void Start()
    {
        dest = this.transform.position;
        v = this.transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > v.y + Y / 2)
        {
            ATK.layer = LayerMask.NameToLayer("FirstTrack");
            COLL.layer = LayerMask.NameToLayer("FirstTrack");
        }
        else if (this.transform.position.y < v.y - Y / 2)
        {
            ATK.layer = LayerMask.NameToLayer("ThirdTrack");
            COLL.layer = LayerMask.NameToLayer("ThirdTrack");
        }
        else
        {
            ATK.layer = LayerMask.NameToLayer("SecondTrack");
            COLL.layer = LayerMask.NameToLayer("SecondTrack");
        }

       
        //移动
        if (Input.GetKeyDown(KeyCode.A))
        {
            //判断是否超出上跑道
            if (this.transform.position.y < v.y + Y / 2)
            {
                dest = new Vector3(this.transform.position.x, this.transform.position.y + Y, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //判断是否超出下跑道
            if (this.transform.position.y > v.y - Y / 2)
            {
                dest = new Vector3(this.transform.position.x, this.transform.position.y - Y, 0);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, dest, move);
    }
}
