using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrackBehavior : MonoBehaviour
{
    public int leftRange;
    public int rightRange;

    public string callName;

    private SimpleTrackController foregroundController;
    private Transform parent;

    private bool haveCreated = false;
    // Start is called before the first frame update
    void Awake()
    {
        foregroundController = GameObject.FindGameObjectWithTag(callName).GetComponent<SimpleTrackController>();
        parent = GameObject.FindGameObjectWithTag(callName).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = parent.TransformPoint(transform.localPosition).x;
        // 跑道移出相机范围后删除
        if (x <= leftRange)
        {
            Destroy(this.gameObject);
        }
        // 跑道移至右侧边界后产生新的跑道
        else if (x <= rightRange && !haveCreated)
        {
            foregroundController.OnCreateTrack();
            haveCreated = true;
        }
    }
}
