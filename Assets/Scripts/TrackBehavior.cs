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
        // 跑道移出相机范围后删除
        if (x <= leftRange)
        {
            Destroy(this.gameObject);
        }
        // 跑道移至右侧边界后产生新的跑道
        else if (x <= rightRange && !haveCreated)
        {
            trackController.OnCreateTrack();
            haveCreated = true;
        }
    }
    // 产生level列的障碍
    public void CreateBlocks(int level)
    {
        // 选择产生障碍的列
        float[] blockX = Common.RandomSelectArray(ref xPosition, level);
        // 选择产生敌人的列
        float enemyX = Common.RandomSelect(ref blockX);
        float[] blockY;
        float z;
        GameObject tmpObject;

        foreach (float x in blockX)
        {
            // 选择产生障碍的行
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
