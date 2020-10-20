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
    public float[] yPosition;
    public float xOffset;
    public bool startCreation = false;

    private Transform parent;
    private int oldRoad = 1;
    private int newRoad = 1;
    private int col = 0;

    private bool onShifting = false;
    public float shiftingDistance = 100f;
    public int shiftingCol = 5;
    private int shiftingColCount = 0;
    private float lastShifting = 0f;

    public int blockRate = 2;
    public float trapRate = 0.05f;
    public float aggressiveEnemyRate = 0.05f;

    public float enemyDistance = 100f;
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
            while (col == 0 || -x / width > col)
            {
                float shiftingChance = (lastShifting - x) / shiftingDistance;
                if (!onShifting && Common.TrueFalseSelect(shiftingChance))
                {
                    shiftingColCount = 0;
                    onShifting = true;
                    ShiftRoad();
                }
                col += 1;
                float xPosition = startPosition + col * width;
                float z;
                for (int i = 0; i < yPosition.Length; i++)
                {
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
                    else if (oldRoad != newRoad && (i == oldRoad || i == newRoad) && Common.TrueFalseSelect(trapRate + aggressiveEnemyRate))
                    {
                        if (Common.TrueFalseSelect(trapRate / (trapRate + aggressiveEnemyRate)))
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
