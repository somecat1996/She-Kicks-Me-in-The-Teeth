using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyGame : MonoBehaviour
{
    public TrackController trackController;
    public SimpleTrackController foregroundController;
    public SimpleTrackController backgroundController;
    public GameController gameController;
    public GameAudioController audioController;

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
