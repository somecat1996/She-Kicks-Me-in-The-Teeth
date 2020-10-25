using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioController : MonoBehaviour
{
    public AudioSource Environment;
    public AudioSource End;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        Environment.Play();
    }

    public void OnPause()
    {
        Environment.Pause();
    }

    public void OnEnd()
    {
        Environment.Stop();
        End.Play();
    }
}
