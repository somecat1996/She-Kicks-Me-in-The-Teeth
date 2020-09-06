using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("初始速度")]
    public float velocity;
    [Header("加速度")]
    public float acceleration;
    [Header("新跑道创建x坐标")]
    public float createPosition;
    [Header("跑道列表")]
    public GameObject[] tracks;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("ZeroTrack").GetComponent<TrackBehavior>().OnInitial(velocity, acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration * Time.deltaTime;
    }

    public void OnCreateTrack()
    {
        GameObject newTrack = GameObject.Instantiate(RandomSelect(), new Vector3(createPosition, 0, 0), Quaternion.identity);
        newTrack.GetComponent<TrackBehavior>().OnInitial(velocity, acceleration);
    }

    private GameObject RandomSelect()
    {
        int num = Random.Range(0, tracks.Length);
        return tracks[num];
    }
}
