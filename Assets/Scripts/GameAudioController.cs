using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioController : MonoBehaviour
{
    public int level = 64;

    public AudioSource Environment;
    public AudioSource End;
    public AudioSource Special;
    // Start is called before the first frame update
    void Start()
    {
        MusicChange();
        SoundChange();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MusicChange()
    {
        Environment.priority = PlayerPrefs.GetInt("Music") * level;
    }

    public void SoundChange()
    {
        End.priority = PlayerPrefs.GetInt("Sound") * level;
        Special.priority = PlayerPrefs.GetInt("Sound") * level;
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

    public void OnSpecial()
    {
        Special.Play();
    }
}
