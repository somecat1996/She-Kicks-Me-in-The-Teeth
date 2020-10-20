﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina1 : MonoBehaviour
{
    [Header("最大耐力值")]
    public float maxStaminaValue;
    [Header("耐力条（Image）")]
    public Image staminaImage;
    [Header("耐力框（Image）")]
    public Image stamina;

    //[Tooltip("耐力条数值文本")]
    //public Text text;

    [Header("恢复耐力条所需时间")]
    public float timer;
    [Header("耐力条每秒回复量")]
    public float secStaminaValue;

    public bool HaoWan;

    // 当前耐力值
    float staminaValue;
    // 通用临时计时器
    float tempTimer = 0;
    // 是否开始回复耐力值
    bool isReply = false;

    private float nl;

    void Start()
    {
        staminaValue = maxStaminaValue;  
    }

    void Update()
    {
        //传值
        nl = GetComponent<PlayerAttack>().staminaValue;

        StartCoroutine(ReplyStamina());
        if (staminaValue > maxStaminaValue)
            staminaValue = maxStaminaValue;

        // 如果一定时间没消耗耐力值就会回复耐力
        if (tempTimer < timer)
            tempTimer += Time.deltaTime;
        else
            isReply = true;
        if (staminaValue<nl)
        {
            HaoWan = true;
        }
        else
        {
            HaoWan = false;
        }

        //数值文本显示
        //text.text = $"{staminaValue}/{maxStaminaValue}";
    }


    /// <summary>
    /// 消耗耐力值
    /// </summary>
    /// <param name="reduceValue">需要消耗的量</param>
    /// <returns>如果消耗成功则返回true，否则返回false</returns>
    public bool ReduceStaminaValue(float reduceValue)
    {
        if (reduceValue > staminaValue)
            return false;
        staminaValue -= reduceValue;
        StartCoroutine(ReduceImageFillAmount());
        isReply = false;
        tempTimer = 0;
        return true;
    }

    // 平滑的减少图片填充
    IEnumerator ReduceImageFillAmount()
    {
        while (staminaValue / maxStaminaValue < staminaImage.fillAmount)
        {
            staminaImage.fillAmount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    // 持续回复耐力
    IEnumerator ReplyStamina()
    {
        if (isReply)
        {
            if (staminaValue >= maxStaminaValue)
                staminaValue = maxStaminaValue;
            else
                staminaValue += secStaminaValue / 100;
            staminaImage.fillAmount = staminaValue / maxStaminaValue;
        }
        yield return new WaitForSeconds(0.01f);
    }
}