using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public TrackController trackController;
    public SimpleTrackController foregroundController;
    public SimpleTrackController backgroundController;
    public GameController gameController;
    [Header("攻击判断框")]
    public GameObject ATK;
    //[Header("攻击伤害")]
    //public float damage;
    [Header("攻击所需消耗的耐力值")]
    public float staminaValue;
    [Header("插入攻击帧的时间")]
    public float atkTime;

    private bool haoWan;

    private Animator animator;
    private AnimationClip[] animationClips;
    public RandomPlayAudio randomPlayAudio;

    //private int attackStage;

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

        //attackStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //传值
        haoWan = GetComponent<Stamina>().HaoWan;

        if (!gameController.end && Input.GetMouseButtonDown(0) && !haoWan && !gameController.end && !gameController.pause)
        {
                //动画播放
                animator.SetTrigger("Attack");
        }
    }
    //攻击开始，通过animator event调用，激活相应collider
    public void OnAttackStart()
    {
        ATK.SetActive(true);
        //播放音效
        randomPlayAudio.RandomPlay();
        GetComponent<Stamina>().ReduceStaminaValue(staminaValue);
    }
    // 一阶攻击结束
    public void OnAttackEnd()
    {
        ATK.SetActive(false);
    }

    // 游戏结束
    public void OnGameEnd()
    {
        foregroundController.OnEnd();
        backgroundController.OnEnd();
        trackController.OnEnd();
        gameController.OnEnd();
    }
    // 初始动画结束后开始游戏
    public void OnGameStart()
    {
        foregroundController.OnStart();
        backgroundController.OnStart();
        trackController.OnStart();
        gameController.OnRun();
    }
}


