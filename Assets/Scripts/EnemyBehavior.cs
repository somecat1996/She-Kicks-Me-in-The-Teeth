using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // 发送相机抖动事件
    private Cinemachine.CinemachineCollisionImpulseSource MyInpulse;
    // Start is called before the first frame update
    void Start()
    {
        MyInpulse = GetComponent<Cinemachine.CinemachineCollisionImpulseSource>();
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
            Wallet.Single.AddGold(1);
            MyInpulse.GenerateImpulse();
            Destroy(gameObject);
        }
    }
}
