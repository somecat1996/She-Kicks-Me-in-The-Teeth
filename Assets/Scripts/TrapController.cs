using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public int middle;

    private Animator anim;
    private Transform parent;
    private bool collapse = false;
    private bool activate = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        parent = GameObject.FindGameObjectWithTag("TrackController").GetComponent<Transform>();
    }

    private void Update()
    {
        float x = parent.TransformPoint(transform.localPosition).x;
        if (x <= middle && !collapse)
        {
            collapse = true;
            anim.SetTrigger("Collapse");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !activate)
        {
            activate = true;
            anim.SetTrigger("Activate");
        }
    }
}
