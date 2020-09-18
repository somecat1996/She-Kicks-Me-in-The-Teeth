using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 游戏结束后产生自由下落的牙齿
public class TeethCreator : MonoBehaviour
{
    public GameObject[] teeth;

    public float X;
    public float Y;

    public float delay;

    private int num;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (num > 0)
        {
            if (timer <= 0)
            {
                GameObject.Instantiate(Common.RandomSelect<GameObject>(ref teeth), new Vector3(X, Y, 0), Quaternion.identity);
                timer = delay;
                num -= 1;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public void SetTeethNumber(int number)
    {
        num = number;
    }
}
