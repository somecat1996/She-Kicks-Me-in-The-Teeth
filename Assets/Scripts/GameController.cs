using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject endUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && Input.GetKeyDown(KeyCode.Escape)) OnPause();
    }

    void OnPause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void OnExit()
    {
        SceneManager.LoadScene(0);
    }

    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnEnd()
    {
        endUI.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
