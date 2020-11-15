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
    [Header("额外速度")]
    public float extraVelocity;
    [Header("加速度")]
    public float acceleration;
    [Header("跑道长度")]
    public float trackLength;
    [Header("跑道偏移")]
    public float trackOffset;
    [Header("跑道列表")]
    public GameObject[] tracks;
    public int level;
    [Header("游戏分数")]
    public float meter;

    public Text meterDisplay;
    public Text meterDisplay2;
    public Text finalMeterDisplay;

    private Rigidbody2D rb;
    private int trackNum;

    private bool end;
    //飙车后速度
    public float tp;
    //判断是否使用初始速度
    private bool first=false;

    //最高分记录
    private float score;
    private float best = 0;

    private bool hasLogged = false;

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
        meterDisplay.text = "Distance: " + math.floor(meter);
        meterDisplay2.text = "Distance: " + math.floor(meter);

        end = true;
        //初始化飙车后速度
        tp= maxVelocity / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            //开始游戏后人物开始加速
            if (velocity <= maxVelocity)
            {
                velocity += acceleration * Time.deltaTime;
                rb.velocity = Vector2.left * velocity;
            }
            //Baby的飙车技能加速功能实现
            if (!(GameObject.Find("Baby") == null))//if (PlayerPrefs.GetString("Selected") == "Baby")
            {
                if (GameObject.Find("Defense Collider").GetComponent<Car>().drive)
                {
                    velocity = extraVelocity;
                    rb.velocity = Vector2.left * velocity;
                    first = true;
                }
                //使用完飙车后Baby的初始速度重置
                else if (tp <= maxVelocity&&first)
                {
                    velocity = tp;
                    velocity += acceleration * Time.deltaTime;
                    rb.velocity = Vector2.left * velocity;
                    //Debug.Log(tp);
                }
            }

            //计分
            meter += System.Math.Abs(rb.velocity.x )* Time.deltaTime;
            meterDisplay.text = "Distance: " + math.floor(meter);
            meterDisplay2.text = "Distance: " + math.floor(meter);
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
        // newTrack.GetComponent<TrackBehavior>().CreateBlocks(level);
    }
    /// <summary>
    /// 游戏结束展示得分
    /// </summary>
    public void OnEnd()
    {
        end = true;
        rb.velocity = Vector2.zero; 
        finalMeterDisplay.text = "Distance: " + math.floor(meter);
        //记录最高分数
        score = math.floor(meter);
        if (score > best)
        {
            best = score;
            bestText.text = "Best：" + best.ToString();
            File.WriteAllText(Application.dataPath + "/StreamingAssets/best.txt", best.ToString());
        }

        if(!hasLogged)
        {
            if (PlayerPrefs.GetInt("TotalScore") < 0) PlayerPrefs.SetInt("TotalScore", (int)score);
            else
            {
                int tmpScore = PlayerPrefs.GetInt("TotalScore");
                PlayerPrefs.SetInt("TotalScore", (int)score + tmpScore);
            }
        }

        if (PlayerPrefs.GetInt("ArchievementTeeth1") == 0 && PlayerPrefs.GetInt("TotalScore") >= 200) PlayerPrefs.SetInt("ArchievementTeeth1", 1);
        if (PlayerPrefs.GetInt("ArchievementTeeth2") == 0 && PlayerPrefs.GetInt("TotalScore") >= 500) PlayerPrefs.SetInt("ArchievementTeeth2", 1);
        if (PlayerPrefs.GetInt("ArchievementTeeth3") == 0 && PlayerPrefs.GetInt("TotalScore") >= 1000) PlayerPrefs.SetInt("ArchievementTeeth3", 1);

        if (PlayerPrefs.GetInt("ArchievementStone") == 0 && score >= 1000) PlayerPrefs.SetInt("ArchievementStone", 1);

        if (PlayerPrefs.GetInt("TotalDeath") <= 0) PlayerPrefs.SetInt("TotalDeath", 1);
        else
        {
            int tmpDeath = PlayerPrefs.GetInt("TotalDeath");
            PlayerPrefs.SetInt("TotalDeath", 1 + tmpDeath);
        }
        if (PlayerPrefs.GetInt("ArchievementFlower1") == 0 && PlayerPrefs.GetInt("TotalDeath") >= 50) PlayerPrefs.SetInt("ArchievementFlower1", 1);
    }
    /// <summary>
    /// 游戏开始
    /// </summary>
    public void OnStart()
    {
        end = false;
    }

    public void Rank()
    {
        //强制转换成int类型，防止读取数据失败
        score = math.floor(meter);
    }

}

