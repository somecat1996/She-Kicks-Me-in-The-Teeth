using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 管理血量，最大血量为5
public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts;
    private int pointer;
    // 血量初始化
    public void Initiate(int num)
    {
        pointer = num - 1;
        for (int i = 0; i < num; i++)
        {
            hearts[i].SetActive(true);
        }
    }
    // 血量+1
    public void Add()
    {
        if (pointer <= 5)
        {
            pointer++;
            hearts[pointer].SetActive(true);
        }
    }
    // 血量-1
    public void Sub()
    {
        if (pointer >= 0)
        {
            hearts[pointer].SetActive(false);
            pointer--;
        }
    }
}
