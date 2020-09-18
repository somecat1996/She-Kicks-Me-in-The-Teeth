using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public TrackController trackController;
    public GameController gameController;
    //[Header("攻击原点")]
    //private Transform attackPosRight;
    //[Header("攻击范围")]
    //public float attackRange;
    //[Header("敌人所在图层")]
    //public LayerMask whatIsEnemies;
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
        //传值
        haoWan = GetComponent<Stamina>().HaoWan;

        if (!gameController.end && Input.GetMouseButtonDown(0) && !haoWan && !gameController.end && !gameController.pause)
        {
            if (attackStage == 0)
            {
                GetComponent<Stamina>().ReduceStaminaValue(staminaValue);
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

    public void OnAttackStart()
    {
        ATK.SetActive(true);
    }

    public void OnAttackEnd()
    {
        if (attackStage >= 2)
        {
            GetComponent<Stamina>().ReduceStaminaValue(staminaValue);
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

    public void OnAttack2End()
    {
        if (attackStage == 3)
        {
            GetComponent<Stamina>().ReduceStaminaValue(staminaValue);
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

    public void OnAttack3End()
    {
        ATK.SetActive(false);
        attackStage = 0;
        animator.SetInteger("Attack Stage", attackStage);
    }

    public void OnGameEnd()
    {
        trackController.OnDisplay();
        gameController.OnEnd();
    }

    public void OnGameStart()
    {
        trackController.OnStart();
    }
}


