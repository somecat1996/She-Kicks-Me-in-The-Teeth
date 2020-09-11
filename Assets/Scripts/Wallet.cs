using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private static Wallet single;
    public static Wallet Single
    {
        get
        {
            if (single == null)
                single = new Wallet();
            return single;
        }
    }
    private float gold;  // 金牙
    public float Gold => gold;

    private Wallet()
    {
        gold = 0;
    }

    /// <summary>
    /// 添加金牙
    /// </summary>
    /// <param name="value">金牙的数量</param>
    /// <returns>如果添加值小于零返回false</returns>
    public bool AddGold(float value)
    {
        if (value < 0)
            return false;
        gold += value;
        return true;
    }
    /// <summary>
    /// 移除金牙or 消费
    /// </summary>
    /// <param name="value">移除的数量</param>
    /// <returns>如果移除值大于现有值返回false</returns>
    public bool RemoveGold(float value)
    {
        if (value > gold)
            return false;
        gold -= value;
        return true;
    }
}

