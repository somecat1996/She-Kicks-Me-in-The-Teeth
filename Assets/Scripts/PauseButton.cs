using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private Animator pauseButtonAnimator;
    private GameController gameController;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseButtonAnimator = GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetActive()
    {
        active = true;
    }

    void UnsetActive()
    {
        active = false;
    }

    public void OnClick()
    {
        if (active)
        {
            pauseButtonAnimator.SetBool("Active", false);
            UnsetActive();
        }
        else
        {
            gameController.OnPause();
            pauseButtonAnimator.SetBool("Active", true);
            SetActive();
        }
    }

    public void OnEnd()
    {
        pauseButtonAnimator.SetBool("Active", true);
        SetActive();
    }

    void OnDeactivate()
    {
        if (gameController.pause)
        {
            gameController.OnResume();
        }
        else if (gameController.end)
        {
            gameController.OnStart();
        }
    }
}
