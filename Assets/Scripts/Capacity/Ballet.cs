using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballet : MonoBehaviour
{
    public bool rotate;

    public float CD;
    private float startCD;

    private void Start()
    {
        rotate = false;
        startCD = CD;
    }

    private void Update()
    {
        if (!rotate&&CD>=0)
        {
            CD -= Time.deltaTime;
        }
        else if (CD<0)
        {
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
        }
        else if(collision.tag == "Block" && !rotate)
        {
            CD = startCD;
        }
    }
}
