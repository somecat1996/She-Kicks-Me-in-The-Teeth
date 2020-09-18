using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // 相机震动源
    public Cinemachine.CinemachineCollisionImpulseSource MyInpulse;

    public Animator anim;

    public int value = 1;

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
        // 在enemy被攻击后，发送抖动
        if (collision.tag == "Attack")
        {
            MyInpulse.GenerateImpulse();
            anim.SetTrigger("Die");
            // 增加牙齿【货币】
            gameController.OnDefeatEnemy(value);
        }
    }
    // <summary>摧毁自身</summary>
    public void SelfDestory()
    {
        Destroy(gameObject);
    }
}
