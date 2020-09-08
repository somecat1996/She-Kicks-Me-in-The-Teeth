using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBehavior : MonoBehaviour
{
    public int leftRange;
    public int rightRange;

    private TrackController trackController;
    private Transform parent;

    private bool haveCreated = false;
    // Start is called before the first frame update
    void Awake()
    {
        trackController = GameObject.FindGameObjectWithTag("TrackController").GetComponent<TrackController>();
        parent = GameObject.FindGameObjectWithTag("TrackController").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = parent.TransformPoint(transform.localPosition).x;

        if (x <= leftRange)
        {
            Destroy(this.gameObject);
        }
        else if (x <= rightRange && !haveCreated)
        {
            trackController.OnCreateTrack();
            haveCreated = true;
        }
    }
}
