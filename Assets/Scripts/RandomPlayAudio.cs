using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public void RandomPlay()
    {
        audioSource.clip = Common.RandomSelect<AudioClip>(ref audioClips);

        audioSource.Play();
    }
}
