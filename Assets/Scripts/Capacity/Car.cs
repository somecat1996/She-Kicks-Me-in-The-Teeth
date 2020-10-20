using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public bool drive;

    public float CD;
    private float startCD;

    public float last;
    private float startLast;

    private void Start()
    {
        drive = false;
        startCD = CD;

        startLast = last;
    }
    //技能冷却计算
    private void Update()
    {
        if (!drive&&CD>=0)
        {
            CD -= Time.deltaTime;
        }
        else if (CD<0)
        {
            drive = true;
            CD = startCD;
        }
    }
    //开车冲刺
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block"&&drive && last >= 0)
        {
            Destroy(collision.gameObject);
            last -= Time.deltaTime;
        }
        else if(collision.tag == "Block" && !drive && last < 0)
        {
            last = startLast;
        }
    }
}
