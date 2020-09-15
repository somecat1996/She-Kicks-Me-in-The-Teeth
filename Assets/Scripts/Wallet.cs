using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        gold = int.Parse(File.ReadAllText(Application.dataPath + "/StreamingAssets/wallet.txt"));
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
        File.WriteAllText(Application.dataPath + "/StreamingAssets/wallet.txt", gold.ToString());
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
        File.WriteAllText(Application.dataPath + "/StreamingAssets/wallet.txt", gold.ToString());
        return true;
    }

}

