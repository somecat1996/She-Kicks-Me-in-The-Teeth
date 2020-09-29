using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // 相机震动源
    public Cinemachine.CinemachineCollisionImpulseSource MyInpulse;

    public Animator anim;

    [Header("芭蕾舞爷爷击打掉落两颗牙齿几率")]
    public float probability=50;

    private GameController gameController;
    // Start is called before the first frame update
    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Attack")
        {
            //牙齿掉落
            int value0=1;
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
            if (rd<= probability)
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
