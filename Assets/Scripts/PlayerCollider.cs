using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public TrackController trackController;
    public GameController gameController;
    public int healthPoint;
    public Animator animator;
    public HealthManager healthManager;

    public Cinemachine.CinemachineCollisionImpulseSource MyInpulse;

    private void Awake()
    {
        healthManager.Initiate(healthPoint);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            healthPoint -= 1;
            healthManager.Sub();
            if (healthPoint <= 0)
            {
                animator.SetTrigger("die");
                trackController.OnEnd();
                MyInpulse.GenerateImpulse();
            }
        }
    }
}
