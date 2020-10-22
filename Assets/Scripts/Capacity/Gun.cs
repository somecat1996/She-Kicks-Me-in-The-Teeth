using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("枪的一些参数")]
    public float attackDistance;//攻击范围
    public float restDistance;//休眠范围
    public float CD;

    private float startCD;
    private bool bomb;

    [Header("子弹的一些参数")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    [Header("芭蕾舞爷爷击打掉落两颗牙齿几率")]
    public float probability = 50;

    private GameObject[] role;

    private GameObject myself;

    // 相机震动源
    public Cinemachine.CinemachineCollisionImpulseSource MyInpulse;

    public Animator anim;
    private GameController gameController;
    // Start is called before the first frame update
    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        role=GameObject.FindGameObjectsWithTag("Player");
        startCD = CD;
    }

    private void Start()
    {
        myself = this.gameObject;
        bomb=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CD>0)
        {
            CD -= Time.deltaTime;
        }
        else if (CD <= 0)
        {
            if (bomb&&Vector2.Distance(role[0].transform.position, transform.position) <= attackDistance && Vector2.Distance(role[0].transform.position, transform.position) > restDistance)
            {
                GameObject tmpObject = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
                tmpObject.layer = myself.layer;
                CD = startCD;
            }
            
        }

        if (Vector2.Distance(role[0].transform.position, transform.position) <=restDistance)
        {
            bomb = false;
        }
        else
        {
            bomb = true;
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
}
