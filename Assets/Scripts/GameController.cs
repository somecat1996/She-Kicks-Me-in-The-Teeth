using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 游戏总控
public class GameController : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject endUI;
    public bool end = false;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 在游戏中监听esc按键暂停
        if (SceneManager.GetActiveScene().buildIndex == 1 && Input.GetKeyDown(KeyCode.Escape)) OnPause();
    }


    // 暂停游戏
    void OnPause()
    {
        Time.timeScale = 0;
        pause = true;
        pauseUI.SetActive(true);
    }
    // 继续游戏，绑定于暂停界面按键
    public void OnResume()
    {
        pause = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
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
        SceneManager.LoadScene(1);
        end = false;
    }
    // 游戏结束，由Player死亡后调用
    public void OnEnd()
    {
        endUI.SetActive(true);
        end = true;
    }
    // 退出游戏，绑定于主菜单按键
    public void OnQuit()
    {
        Application.Quit();
    }
}
