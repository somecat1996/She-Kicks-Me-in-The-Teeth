using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [Header("普通敌人")]
    public GameObject[] NormalEnemies;
    [Header("攻击敌人")]
    public GameObject[] AggressiveEnemies;
    [Header("障碍")]
    public GameObject[] Blocks;
    [Header("陷阱")]
    public GameObject[] Traps;

    [Header("障碍宽度")]
    public float width;
    [Header("障碍开始位置")]
    public float startPosition;
    // 障碍纵向位置
    public float[] yPosition;
    // 障碍偏移
    public float xOffset;
    // 为true时创建障碍
    public bool startCreation = false;

    private Transform parent;
    private int oldRoad = 1;
    private int newRoad = 1;
    private int col = 0;

    // 换行标志
    private bool onShifting = false;
    // 换行距离，经过shiftingDistance必定换行，否则按一定概率换行
    public float shiftingDistance = 100f;
    // 换行状态持续的列
    public int shiftingCol = 5;
    // 记录当前换行状态
    private int shiftingColCount = 0;
    // 记录上次换行位置
    private float lastShifting = 0f;

    // 障碍产生率，越大增加速度越快
    public int blockRate = 2;
    // 陷阱产生概率
    public float trapRate = 0.05f;
    // 攻击敌人产生概率
    public float aggressiveEnemyRate = 0.05f;

    // 敌人距离
    public float enemyDistance = 100f;
    // 上个敌人位置
    private float lastEnemy = 0f;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("TrackController").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCreation)
        {
            float x = parent.TransformPoint(transform.localPosition).x;
            // 按宽度产生障碍
            while (col == 0 || -x / width > col)
            {
                // 按概率换行
                float shiftingChance = (lastShifting - x) / shiftingDistance;
                if (!onShifting && Common.TrueFalseSelect(shiftingChance))
                {
                    shiftingColCount = 0;
                    onShifting = true;
                    ShiftRoad();
                }
                // 产生障碍
                col += 1;
                float xPosition = startPosition + col * width;
                float z;
                for (int i = 0; i < yPosition.Length; i++)
                {
                    // 在非road行创建障碍
                    if (i != oldRoad && i != newRoad && Common.TrueFalseSelect((1f - math.pow(blockRate, x / 100)) * .75f))
                    {
                        GameObject tmpObject = GameObject.Instantiate(Common.RandomSelect(ref Blocks), Vector3.zero, Quaternion.identity, transform);
                        switch (i)
                        {
                            case 0: tmpObject.layer = LayerMask.NameToLayer("FirstTrack"); z = 1.5f; break;
                            case 1: tmpObject.layer = LayerMask.NameToLayer("SecondTrack"); z = 0; break;
                            case 2: tmpObject.layer = LayerMask.NameToLayer("ThirdTrack"); z = -1.5f; break;
                            default: z = 0; break;
                        }
                        tmpObject.transform.localPosition = new Vector3(xPosition + i * xOffset, yPosition[i], z);
                    }
                    // 在road行创建敌人
                    else if ((i == oldRoad || i == newRoad) && Common.TrueFalseSelect((lastEnemy - x) / enemyDistance))
                    {
                        lastEnemy = x;
                        GameObject tmpObject = GameObject.Instantiate(Common.RandomSelect(ref NormalEnemies), Vector3.zero, Quaternion.identity, transform);
                        switch (i)
                        {
                            case 0: tmpObject.layer = LayerMask.NameToLayer("FirstTrack"); z = 1.5f; break;
                            case 1: tmpObject.layer = LayerMask.NameToLayer("SecondTrack"); z = 0; break;
                            case 2: tmpObject.layer = LayerMask.NameToLayer("ThirdTrack"); z = -1.5f; break;
                            default: z = 0; break;
                        }
                        tmpObject.transform.localPosition = new Vector3(xPosition + i * xOffset, yPosition[i], z);
                    }
                    // 在road转换处创建陷阱和攻击敌人
                    else if (oldRoad != newRoad && (i == oldRoad || i == newRoad) && Common.TrueFalseSelect(trapRate + aggressiveEnemyRate))
                    {
                        if (Common.TrueFalseSelect(trapRate / (trapRate + aggressiveEnemyRate)) && shiftingColCount != 0 && shiftingColCount != shiftingCol - 1)
                        {
                            GameObject tmpObject = GameObject.Instantiate(Common.RandomSelect(ref Traps), Vector3.zero, Quaternion.identity, transform);
                            switch (i)
                            {
                                case 0: tmpObject.layer = LayerMask.NameToLayer("FirstTrack"); z = 1.5f; break;
                                case 1: tmpObject.layer = LayerMask.NameToLayer("SecondTrack"); z = 0; break;
                                case 2: tmpObject.layer = LayerMask.NameToLayer("ThirdTrack"); z = -1.5f; break;
                                default: z = 0; break;
                            }
                            tmpObject.transform.localPosition = new Vector3(xPosition + i * xOffset, yPosition[i], z);
                        }
                        else
                        {

                        }
                    }

                }

                // 换行状态
                if (onShifting)
                {
                    shiftingColCount += 1;
                    if (shiftingCol == shiftingColCount)
                    {
                        onShifting = false;
                        oldRoad = newRoad;
                        lastShifting = x;
                    }
                }
            }
        }
    }

    public void OnStart()
    {
        startCreation = true;
    }

    public void OnStop()
    {
        startCreation = false;
    }

    // 跳转路线
    private void ShiftRoad()
    {
        int[] selectFrom = new int[2] { 0, 2 };
        switch (oldRoad)
        {
            case 0: newRoad = 1; break;
            case 1: newRoad = Common.RandomSelect<int>(ref selectFrom); break;
            case 2: newRoad = 1; break;
            default: newRoad = 1;break;
        }
    }
}
