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

    private bool canAttack;

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

        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        //传值
        haoWan = GetComponent<Stamina>().HaoWan;

        if (canAttack&&Input.GetMouseButtonDown(0) && !haoWan && !gameController.end && !gameController.pause)
        {
            GetComponent<Stamina>().ReduceStaminaValue(staminaValue);
            //动画播放
            animator.SetTrigger("attacking");
            //播放音效
            randomPlayAudio.RandomPlay();
        }
    }

    public void OnAttackStart()
    {
        ATK.SetActive(true);

        canAttack = false;
    }

    public void OnAttackEnd()
    {
        ATK.SetActive(false);

        canAttack = true;
    }

    public void OnGameEnd()
    {
        trackController.OnDisplay();
        gameController.OnEnd();
    }
}


