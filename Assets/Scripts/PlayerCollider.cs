using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public TrackController trackController;
    public SimpleTrackController foregroundController;
    public SimpleTrackController backgroundController;
    public GameController gameController;
    [Header("角色血量")]
    public int healthPoint;
    public Animator animator;
    public HealthManager healthManager;
    [Header("受伤后相机震动源")]
    public Cinemachine.CinemachineCollisionImpulseSource MyInpulse;
    [Header("受伤后需要闪烁的图片")]
    public SpriteRenderer twinkle;
    [Header("无敌持续时间")]
    public float invincibleTime;
    //private float timeSpentInvincible=0;

    private float timer=0;
    private bool invincible;

    private void Awake()
    {
        healthManager.Initiate(healthPoint);

        timer = 0;
        invincible = false;
    }

    private void Update()
    {
        // 减少无敌时间
        if (invincible)
        {
            timer += Time.deltaTime;
            if (timer >= invincibleTime)
            {
                twinkle.enabled = true;

                invincible = false;
                timer = 0;
            }
            else
            {
                //将计时器中时间取余，如果余大于0.1则图片消失
                float remainder = timer % 0.3f;
                twinkle.enabled = remainder > 0.1f;
                //Debug.Log(remainder);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block" && !invincible)
        {
            // 减少角色健康
            healthPoint -= 1;
            healthManager.Sub();
            // 发送摄像机震动事件
            MyInpulse.GenerateImpulse();
            // 设置角色无敌
            invincible = true;

            if (healthPoint <= 0)
            {
                //死亡时无闪动效果
                invincible = false;
                // 角色死亡动画
                animator.SetTrigger("die");
                // 停止场景移动
                trackController.OnEnd();
                foregroundController.OnEnd();
                backgroundController.OnEnd();
            }
        }
        if (collision.tag == "Bullet")
        {
            // 减少角色健康
            healthPoint -= 1;
            healthManager.Sub();
            // 设置角色无敌
            invincible = true;
            if (healthPoint <= 0)
            {
                //死亡时无无敌效果
                invincible = false;
                // 角色死亡动画
                animator.SetTrigger("die");
                // 停止场景移动
                trackController.OnEnd();
                foregroundController.OnEnd();
                backgroundController.OnEnd();
            }
        }
    }
}

