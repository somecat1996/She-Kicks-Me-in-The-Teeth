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
        gold = int.Parse(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "wallet.txt")));
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

        if (PlayerPrefs.GetInt("ArchievementKnife") == 0 && value >= 100) PlayerPrefs.SetInt("ArchievementKnife", 1);

        gold += value;

        if (PlayerPrefs.GetInt("ArchievementMedicine") == 0 && value >= 10000) PlayerPrefs.SetInt("ArchievementMedicine", 1);

        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "wallet.txt"), gold.ToString());
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
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "wallet.txt"), gold.ToString());
        return true;
    }

    public void Reset()
    {
        gold = 0;
        // File.WriteAllText(Application.dataPath + "/StreamingAssets/wallet.txt", gold.ToString());
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "wallet.txt"), gold.ToString());
    }

}

