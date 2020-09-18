using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts;
    private int pointer;
    public void Initiate(int num)
    {
        pointer = num - 1;
        for (int i = 0; i < num; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    public void Add()
    {
        if (pointer <= 5)
        {
            pointer++;
            hearts[pointer].SetActive(true);
        }
    }

    public void Sub()
    {
        if (pointer >= 0)
        {
            hearts[pointer].SetActive(false);
            pointer--;
        }
    }
}
