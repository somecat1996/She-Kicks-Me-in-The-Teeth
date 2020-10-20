using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public int leftRange = -20;
    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("TrackController").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = parent.TransformPoint(transform.localPosition).x;
        // 移出相机范围后删除
        if (x <= leftRange)
        {
            Destroy(this.gameObject);
        }
    }
}
