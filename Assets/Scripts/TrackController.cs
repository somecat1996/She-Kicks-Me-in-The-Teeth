using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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

    //最高分记录
    private float score;
    private float best = 0;

    public float Best
    {
        get; set;
    }

    [Header("最高分文本组件")]
    public Text bestText;

    // Start is called before the first frame update
    void Awake()
    {
        // 读取文件中的最高分记录
        // 注意第一次时文本内容不能为空，否则报错
        best = int.Parse(File.ReadAllText(Application.dataPath + "/StreamingAssets/best.txt"));
        bestText.text = "Best：" + best.ToString();

        rb = GetComponent<Rigidbody2D>();
        trackNum = 1;

        meter = 0;
        meterDisplay.text = "Meter: " + math.floor(meter);

        end = true;
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
        Rank();
    }
    /// <summary>
    /// 最右跑道移动至相机边界时调用，产生新跑道
    /// </summary>
    public void OnCreateTrack()
    {
        GameObject newTrack = GameObject.Instantiate(Common.RandomSelect(ref tracks), Vector3.zero, Quaternion.identity, transform);
        newTrack.transform.localPosition = new Vector3(trackNum * trackLength + trackOffset, 0, 0);
        trackNum += 1;
        newTrack.GetComponent<TrackBehavior>().CreateBlocks(level);
    }
    /// <summary>
    /// 游戏结束展示得分
    /// </summary>
    public void OnEnd()
    {
        end = true;
        rb.velocity = Vector2.zero;
        //记录最高分数
        score = math.floor(meter);
        if (score > best)
        {
            best = score;
            bestText.text = "Best：" + best.ToString();
            File.WriteAllText(Application.dataPath + "/StreamingAssets/best.txt", best.ToString());
        }
    }

    public void OnStart()
    {
        end = false;
    }

    public void OnDisplay()
    {
        finalMeterDisplay.text = "Meter: " + math.floor(meter);
        rb.velocity = Vector2.zero;
    }

    public void Rank()
    {
        //强制转换成int类型，防止读取数据失败
        score = math.floor(meter);
    }

}

