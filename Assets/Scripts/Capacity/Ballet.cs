using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballet : MonoBehaviour
{
    public GameObject body;
    public Animator animator;

    public bool rotate;

    public float CD;
    private float startCD;

    private void Start()
    {
        //插入动画
        //animator = GetComponent<Animator>();

        rotate = false;
        startCD = CD;
    }

    private void Update()
    {
        if (!rotate&&CD>=0)
        {
            //开启角色可以被伤害判定
            body.SetActive(true);
            CD -= Time.deltaTime;
        }
        else if (CD<0)
        {
            animator.SetBool("Dance", true);
            //关闭角色可以被伤害判定
            body.SetActive(false);
            rotate = true;
            CD = startCD;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block"&&rotate)
        {
            Destroy(collision.gameObject);
            rotate = false;

            animator.SetBool("Dance", false);
        }
        else if(collision.tag == "Block" && !rotate)
        {
            CD = startCD;
        }
    }
}
