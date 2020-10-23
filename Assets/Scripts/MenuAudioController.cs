using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    public AudioSource environment;
    public AudioSource payment;
    public AudioSource error;
    public AudioSource boxOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOpenBox()
    {
        boxOpen.Play();
    }

    public void OnPay()
    {
        payment.Play();
    }

    public void OnError()
    {
        error.Play();
    }
}
