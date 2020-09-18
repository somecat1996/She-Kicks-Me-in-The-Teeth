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
}
