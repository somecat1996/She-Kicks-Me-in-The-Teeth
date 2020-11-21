using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public MenuAudioController audioController;

    public Sprite Active;
    public Sprite Inactive;

    public Image[] Music;
    public Image[] Sound;

    void Start()
    {
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
            PlayerPrefs.SetInt("Music", 2);
            PlayerPrefs.SetInt("Sound", 2);
            PlayerPrefs.SetInt("FirstStart", 1);
        }

        for (int i = 0; i < PlayerPrefs.GetInt("Music"); i++)
            Music[i].sprite = Active;
        for (int i = PlayerPrefs.GetInt("Music"); i < 3; i++)
            Music[i].sprite = Inactive;

        for (int i = 0; i < PlayerPrefs.GetInt("Sound"); i++)
            Sound[i].sprite = Active;
        for (int i = PlayerPrefs.GetInt("Sound"); i < 3; i++)
            Sound[i].sprite = Inactive;

        audioController.MusicChange();
        audioController.SoundChange();
    }
    public void MusicUp()
    {
        if (PlayerPrefs.GetInt("Music") >= 3)
        {
            audioController.OnError();
        }
        else
        {
            Music[PlayerPrefs.GetInt("Music")].sprite = Active;
            PlayerPrefs.SetInt("Music", PlayerPrefs.GetInt("Music") + 1);
            audioController.MusicChange();
        }
    }

    public void MusicDown()
    {
        if (PlayerPrefs.GetInt("Music") <= 0)
        {
            audioController.OnError();
        }
        else
        {
            PlayerPrefs.SetInt("Music", PlayerPrefs.GetInt("Music") - 1);
            Music[PlayerPrefs.GetInt("Music")].sprite = Inactive;
            audioController.MusicChange();
        }
    }

    public void SoundUp()
    {
        if (PlayerPrefs.GetInt("Sound") >= 3)
        {
            audioController.OnError();
        }
        else
        {
            Sound[PlayerPrefs.GetInt("Sound")].sprite = Active;
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") + 1);
            audioController.SoundChange();
        }
    }

    public void SoundDown()
    {
        if (PlayerPrefs.GetInt("Sound") <= 0)
        {
            audioController.OnError();
        }
        else
        {
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound") - 1);
            Sound[PlayerPrefs.GetInt("Sound")].sprite = Inactive;
            audioController.SoundChange();
        }
    }
}
