using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) OnPause();
    }

    void OnPause()
    {
        Time.timeScale = 0;
        ui.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        ui.SetActive(false);
    }
}
