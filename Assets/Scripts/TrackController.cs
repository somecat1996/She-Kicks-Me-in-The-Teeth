using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    [Header("初始速度")]
    public float velocity;
    [Header("加速度")]
    public float acceleration;
    [Header("新跑道创建x坐标")]
    public float offset;
    [Header("跑道列表")]
    public GameObject[] tracks;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration * Time.deltaTime;
        rb.velocity = Vector2.left * velocity;
    }

    public void OnCreateTrack()
    {
        GameObject.Instantiate(RandomSelect(), new Vector3(offset, 0, 0), Quaternion.identity, transform);
    }

    private GameObject RandomSelect()
    {
        int num = Random.Range(0, tracks.Length);
        return tracks[num];
    }
}
