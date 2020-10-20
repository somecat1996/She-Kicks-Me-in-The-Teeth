using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyGame : MonoBehaviour
{
    public TrackController trackController;
    public GameController gameController;
    // 游戏结束
    public void OnGameEnd()
    {
        trackController.OnEnd();
        gameController.OnEnd();
    }
    // 初始动画结束后开始游戏
    public void OnGameStart()
    {
        trackController.OnStart();
        gameController.OnRun();
    }
}
