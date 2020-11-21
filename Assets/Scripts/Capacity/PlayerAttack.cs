using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public TrackController trackController;
    public SimpleTrackController foregroundController;
    public SimpleTrackController backgroundController;
    public GameController gameController;
    public GameAudioController audioController;
    [Header("攻击判断框")]
    public GameObject ATK;
    [Header("攻击伤害")]
    public float damage;
    [Header("攻击所需消耗的耐力值")]
    public float staminaValue;
    [Header("插入攻击帧的时间")]
    public float atkTime;

    private bool haoWan;

    private Animator animator;
    private AnimationClip[] animationClips;
    public RandomPlayAudio randomPlayAudio;

    private int attackStage;

    private void Start()
    {
        //插入动画
        animator = GetComponent<Animator>();
        animationClips = animator.runtimeAnimatorController.animationClips;

        for (int i = 0; i < animationClips.Length; i++)
        {
            if (animationClips[i].name == "PlayerAttack")
            {
                AnimationEvent _event = new AnimationEvent();
                _event.functionName = "PeopleAttack";
                _event.time = atkTime;
                animationClips[i].AddEvent(_event);
                break;
            }
        }

        attackStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ////传值
        //haoWan = GetComponent<Stamina1>().HaoWan;

        //if (!gameController.end && Input.GetMouseButtonDown(0) && !haoWan && !gameController.end && !gameController.pause)
        //{
        //    if (attackStage == 0)
        //    {
        //        GetComponent<Stamina1>().ReduceStaminaValue(staminaValue);
        //        //动画播放
        //        attackStage = 1;
        //        animator.SetInteger("Attack Stage", attackStage);
        //        //播放音效
        //        randomPlayAudio.RandomPlay();
        //    }
        //    else if (attackStage == 1)
        //    {
        //        attackStage = 2;
        //    }
        //    else if (attackStage == 2)
        //    {
        //        attackStage = 3;
        //    }
        //}
    }

    public void Attack()
    {
        haoWan = GetComponent<Stamina1>().HaoWan;

        if (!gameController.end && !haoWan && !gameController.end && !gameController.pause)
        {
            if (attackStage == 0)
            {
                GetComponent<Stamina1>().ReduceStaminaValue(staminaValue);
                //动画播放
                attackStage = 1;
                animator.SetInteger("Attack Stage", attackStage);
                //播放音效
                randomPlayAudio.RandomPlay();
            }
            else if (attackStage == 1)
            {
                attackStage = 2;
            }
            else if (attackStage == 2)
            {
                attackStage = 3;
            }
        }
    }
    // 攻击开始，通过animator event调用，激活相应collider
    public void OnAttackStart()
    {
        ATK.SetActive(true);
    }
    // 一阶攻击结束，判断是否进入二阶攻击
    public void OnAttackEnd()
    {
        if (attackStage >= 2)
        {
            GetComponent<Stamina1>().ReduceStaminaValue(staminaValue);
            animator.SetInteger("Attack Stage", 2);
            //播放音效
            randomPlayAudio.RandomPlay();
        }
        else
        {
            ATK.SetActive(false);
            attackStage = 0;
            animator.SetInteger("Attack Stage", attackStage);
        }
    }
    // 二阶攻击结束，判断是否进入三阶攻击
    public void OnAttack2End()
    {
        if (attackStage == 3)
        {
            GetComponent<Stamina1>().ReduceStaminaValue(staminaValue);
            animator.SetInteger("Attack Stage", attackStage);
            //播放音效
            randomPlayAudio.RandomPlay();
        }
        else
        {
            ATK.SetActive(false);
            attackStage = 0;
            animator.SetInteger("Attack Stage", attackStage);
        }
    }
    // 三阶攻击结束，禁用collider
    public void OnAttack3End()
    {
        ATK.SetActive(false);
        attackStage = 0;
        animator.SetInteger("Attack Stage", attackStage);
    }
    // 游戏结束
    public void OnGameEnd()
    {
        foregroundController.OnEnd();
        backgroundController.OnEnd();
        trackController.OnEnd();
        gameController.OnEnd();
        audioController.OnEnd();
    }
    // 初始动画结束后开始游戏
    public void OnGameStart()
    {
        foregroundController.OnStart();
        backgroundController.OnStart();
        trackController.OnStart();
        gameController.OnRun();
        audioController.OnStart();
    }
}


