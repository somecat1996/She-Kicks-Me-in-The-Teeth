using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBehavior : MonoBehaviour
{
    public int leftRange;
    public int rightRange;

    public float[] xPosition;
    public float[] yPosition;
    public float xOffset;

    public GameObject[] Enemies;
    public GameObject[] Blocks;

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

    public void CreateBlocks(int level)
    {
        float[] blockX = Common.RandomSelectArray(ref xPosition, level);
        float enemyX = Common.RandomSelect(ref blockX);
        float[] blockY;
        float z;
        GameObject tmpObject;

        foreach (float x in blockX)
        {
            blockY = Common.RandomSelectArray(ref yPosition, 2);

            for (int i = 0; i < yPosition.Length; i++)
            {
                if (yPosition[i] == blockY[0] || yPosition[i] == blockY[1])
                {
                    tmpObject = GameObject.Instantiate(Common.RandomSelect(ref Blocks), Vector3.zero, Quaternion.identity, transform);
                    switch (i)
                    {
                        case 0: tmpObject.layer = LayerMask.NameToLayer("FirstTrack"); z = 1.5f; break;
                        case 1: tmpObject.layer = LayerMask.NameToLayer("SecondTrack"); z = 0; break;
                        case 2: tmpObject.layer = LayerMask.NameToLayer("ThirdTrack"); z = -1.5f; break;
                        default: z = 0; break;
                    }
                    tmpObject.transform.localPosition = new Vector3(x + i * xOffset, yPosition[i], z);
                }
                else if (enemyX == x)
                {
                    tmpObject = GameObject.Instantiate(Common.RandomSelect(ref Enemies), Vector3.zero, Quaternion.identity, transform);
                    switch (i)
                    {
                        case 0: tmpObject.layer = LayerMask.NameToLayer("FirstTrack"); z = 1.5f; break;
                        case 1: tmpObject.layer = LayerMask.NameToLayer("SecondTrack"); z = 0; break;
                        case 2: tmpObject.layer = LayerMask.NameToLayer("ThirdTrack"); z = -1.5f; break;
                        default: z = 0; break;
                    }
                    tmpObject.transform.localPosition = new Vector3(x + i * xOffset, yPosition[i], z);
                }
            }
        }
    }
}
