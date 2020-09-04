using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [Header("记录人物位置延迟时间")]
    public float time;
    private bool pT;

    [Header("人物上下移动距离")]
    public float Y;
    [Header("切换赛道速度")]
    public float move;

    private Vector3 dest;
    private Vector3 v;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pT)
        {
            Invoke("Wait", time);
        }
        
        //移动
        if (Input.GetKeyDown(KeyCode.A))
        {
            //判断是否超出跑道
            if (this.transform.position.y <=v.y)
            {
                dest = new Vector3(this.transform.position.x, this.transform.position.y + Y, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //判断是否超出跑道
            if (this.transform.position.y >= v.y)
            {
                dest = new Vector3(this.transform.position.x, this.transform.position.y - Y, 0);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, dest, move);
    }

    private void OnLevelWasLoaded(int level)
    {
        //记录初始位置
        v = transform.position;
        pT = false;
    }
}
