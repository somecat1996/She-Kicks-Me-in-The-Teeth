using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    /// <summary>
    /// 在audioClips中随机选取音频，使用audioSource播放
    /// </summary>
    public void RandomPlay()
    {
        audioSource.clip = Common.RandomSelect<AudioClip>(ref audioClips);

        audioSource.Play();
    }
}
