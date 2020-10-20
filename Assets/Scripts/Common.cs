using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 公用函数
public class Common : MonoBehaviour
{
    // <summary>在元组中随机选取一项</summary>
    public static T RandomSelect<T>(ref T[] array)
    {
        int num = Random.Range(0, array.Length);
        return array[num];
    }
    // <summary>在元组中随机选取count项</summary>
    public static T[] RandomSelectArray<T>(ref T[] paramArray, int count)
    {
        if (paramArray.Length < count)
        {
            return paramArray;
        }
        T[] newArray = new T[count];
        int temp;
        List<int> list = new List<int>();
        for (int i = 1; i <= count; i++)
        {
            temp = Random.Range(0, paramArray.Length);
            while (list.Contains(temp))
            {
                temp = Random.Range(0, paramArray.Length);
            }
            newArray[i - 1] = paramArray[temp];
            list.Add(temp);
        }
        return newArray;
    }

    public static T ChanceSelect<T>(ref T[] itemArray, float[] chanceArray, ref T def)
    {
        if (itemArray.Length != chanceArray.Length) return def;
        float c = Random.Range(0, 1);
        float sum = 0;
        for (int i = 0; i < itemArray.Length; i++)
        {
            sum += chanceArray[i];
            if (sum > c)
            {
                return itemArray[i];
            }
        }
        return def;
    }

    public static bool TrueFalseSelect(float chance)
    {
        float c = Random.Range(0f, 1f);
        if (chance >= c) return true;
        else return false;
    }
}
