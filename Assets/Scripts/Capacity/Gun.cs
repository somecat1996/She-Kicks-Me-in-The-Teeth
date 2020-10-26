using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("枪的一些参数")]
    public float restDistance;//休眠范围

    public float CD;
    public float startCD;

    [Header("子弹的一些参数")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    [Header("Aun击打掉落两颗牙齿几率")]
    public float probability = 50;

    public Animator anim;
    private GameObject[] role;
    private GameController gameController;
    private bool first;

    // 相机震动源
    public Cinemachine.CinemachineCollisionImpulseSource MyInpulse;

    // Start is called before the first frame update
    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        role=GameObject.FindGameObjectsWithTag("Player");
    }

    private void Start()
    {
        //Shoot(this.gameObject);
        //myself = this.gameObject;
        startCD = CD;
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            anim.SetTrigger("Shooting");
            first = false;
        }

        if (CD>=0)
        {
            CD -= Time.deltaTime;
        }
        else if (CD <0)
        {
            anim.SetTrigger("Shooting");
            CD = startCD;
        }

        //如果玩家靠近攻击路人转动画状态
        if (Vector2.Distance(role[0].transform.position, transform.position) <= restDistance)
        {
            Debug.Log(role[0]);
            anim.SetTrigger("Sleeping");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Attack")
        {
            //牙齿掉落
            int value0 = 1;
            // 在enemy被攻击后，发送抖动
            MyInpulse.GenerateImpulse();
            // 播放动画
            anim.SetTrigger("Die");
            // 增加牙齿【货币】
            gameController.OnDefeatEnemy(value0);
        }
        //如果是芭蕾舞爷爷则有几率掉落更多牙齿，其攻击框Tag为Attack1
        else if (collision.tag == "Attack1")
        {
            MyInpulse.GenerateImpulse();
            anim.SetTrigger("Die");
            // 增加更多牙齿【货币】
            int rd = Random.Range(0, 100);
            if (rd <= probability)
            {
                int value1 = 2;
                gameController.OnDefeatEnemy(value1);
            }
            else
            {
                int value2 = 1;
                gameController.OnDefeatEnemy(value2);
            }
        }
    }
    // <summary>摧毁自身</summary>
    public void SelfDestory()
    {
        Destroy(gameObject);
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}
