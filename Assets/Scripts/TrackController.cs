using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

// 控制地图向左运动
public class TrackController : MonoBehaviour
{
    [Header("初始速度")]
    public float velocity;
    [Header("最大速度")]
    public float maxVelocity;
    [Header("加速度")]
    public float acceleration;
    [Header("跑道长度")]
    public float trackLength;
    [Header("跑道偏移")]
    public float trackOffset;
    [Header("跑道列表")]
    public GameObject[] tracks;
    public int level;

    public Text meterDisplay;
    public Text finalMeterDisplay;

    public float meter;

    private Rigidbody2D rb;
    private int trackNum;

    private bool end;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trackNum = 1;

        meter = 0;
        meterDisplay.text = "Meter: " + math.floor(meter);

        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            if (velocity <= maxVelocity)
            {
                velocity += acceleration * Time.deltaTime;
                rb.velocity = Vector2.left * velocity;
            }

            meter += velocity * Time.deltaTime;
            meterDisplay.text = "Meter: " + math.floor(meter);
        }
    }
    // 最右跑道移动至相机边界时调用，产生新跑道
    public void OnCreateTrack()
    {
        GameObject newTrack = GameObject.Instantiate(Common.RandomSelect(ref tracks), Vector3.zero, Quaternion.identity, transform);
        newTrack.transform.localPosition = new Vector3(trackNum * trackLength + trackOffset, 0, 0);
        trackNum += 1;
        newTrack.GetComponent<TrackBehavior>().CreateBlocks(level);
    }
    // 游戏结束展示得分
    public void OnEnd()
    {
        end = true;
        finalMeterDisplay.text = "Meter: " + math.floor(meter);
        rb.velocity = Vector2.zero;
    }
}
