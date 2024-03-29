﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 游戏总控
public class GameController : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject endUI;
    public GameObject mask;
    public GameObject teethUI;
    public bool end;
    public bool pause = false;

    public PauseButton pauseButton;

    private int teeth;
    // Start is called before the first frame update
    void Awake()
    {
        teeth = 0;
        end = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 在游戏中监听esc按键暂停
        if (SceneManager.GetActiveScene().buildIndex != 0 && Input.GetKeyDown(KeyCode.Escape)) OnPause();
    }


    // 暂停游戏
    public void OnPause()
    {
        Time.timeScale = 0;
        pause = true;
        pauseUI.SetActive(true);
        mask.SetActive(true);
    }
    // 继续游戏，绑定于暂停界面按键
    public void OnResume()
    {
        pause = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        mask.SetActive(false);
    }
    // 返回主菜单，绑定于暂停界面按键
    public void OnExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    // 开始游戏，绑定于主菜单界面按键
    public void OnStart()
    {
        SceneManager.LoadScene(SelectCharacter());
    }

    public void OnRun()
    {

        end = false;
    }
    // 游戏结束，由Player死亡后调用
    public void OnEnd()
    {
        endUI.SetActive(true);
        mask.SetActive(true);
        end = true;
        teethUI.SetActive(true);
        teethUI.GetComponent<TeethCreator>().SetTeethNumber(teeth);

        pauseButton.OnEnd();
    }
    // 退出游戏，绑定于主菜单按键
    public void OnQuit()
    {
        Application.Quit();
    }
    // 击败敌人后增加相应数量牙齿
    public void OnDefeatEnemy(int teethNum)
    {
        Wallet.Single.AddGold(teethNum);
        teeth += teethNum;
    }
    // 设置角色，根据角色加载场景
    private int SelectCharacter()
    {
        switch (PlayerPrefs.GetString("Selected"))
        {
            case "Grandma": return 1;
            case "Grandpa": return 2;
            case "Girl": return 3;
            case "Baby": return 4;
            case "Auntie": return 5;
            default: PlayerPrefs.SetString("Selected", "Grandma"); return 1;
        }
    }
}
