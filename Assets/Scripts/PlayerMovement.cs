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


    public GameObject hull;

    

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
            hull.layer = LayerMask.NameToLayer("FirstTrack");
        }
        else if (this.transform.position.y < v.y - Y / 2)
        {
            hull.layer = LayerMask.NameToLayer("ThirdTrack");
        }
        else
        {
            hull.layer = LayerMask.NameToLayer("SecondTrack");
        }

       
        //移动
        if (Input.GetKeyDown(KeyCode.A))
        {
            //判断是否超出上跑道
            if (this.transform.position.y < v.y + Y / 2)
            {
<<<<<<< HEAD
                dest = new Vector3(this.transform.position.x, this.transform.position.y + Y, 0);
                hull.layer = LayerMask.NameToLayer("FirstTrack");
=======
                dest = new Vector3(this.transform.position.x, this.transform.position.y + Y, this.transform.position.z + Y);
>>>>>>> 7c3d824536983412121377056771586c944e3b1a
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //判断是否超出下跑道
            if (this.transform.position.y > v.y - Y / 2)
            {
<<<<<<< HEAD
                dest = new Vector3(this.transform.position.x, this.transform.position.y - Y, 0);
                hull.layer = LayerMask.NameToLayer("ThirdTrack");
=======
                dest = new Vector3(this.transform.position.x, this.transform.position.y - Y, this.transform.position.z - Y);
>>>>>>> 7c3d824536983412121377056771586c944e3b1a
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, dest, move);
    }
}
