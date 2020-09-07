﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("攻击原点")]
    private Transform attackPosRight;
    [Header("攻击范围")]
    public float attackRange;
    [Header("敌人所在图层")]
    public LayerMask whatIsEnemies;
    [Header("攻击伤害")]
    public float damage;
    [Header("攻击所需消耗的耐力值")]
    public float staminaValue;

    private bool haoWan;

    private Animator animator;
    private AnimationClip[] animationClips;

    private void Start()
    {
        attackPosRight = transform.Find("Attack");
        animator = GetComponent<Animator>();
        animationClips = animator.runtimeAnimatorController.animationClips;
        for (int i = 0; i < animationClips.Length; i++)
        {
            if (animationClips[i].name == "PlayerAttack")
            {
                AnimationEvent _event = new AnimationEvent();
                _event.functionName = "PeopleAttack";
                _event.time = 0.1f;
                animationClips[i].AddEvent(_event);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //传值
        haoWan = GetComponent<Stamina>().HaoWan;

        if (Input.GetMouseButtonDown(0)&&!haoWan)
        {
            GetComponent<Stamina>().ReduceStaminaValue(staminaValue);
            //动画播放
            animator.SetTrigger("attacking");
        }
    }

    private void PeopleAttack()
    {
        #region
        //AudioManager.PlayerAttackAudio();
        //Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosRight.position, attackRange, whatIsEnemies);
        //for (int i = 0; i < enemies.Length; i++)
        //{
        //    Enemy tempEnemy = enemies[i].GetComponent<Enemy>();
        //    if (tempEnemy != null)
        //    {
        //        tempEnemy.ReduceBlood(gameObject, damage, HitType.puTon, PlayerSkillType.commonHit);
        //    }

        //}
        #endregion
    }
}

