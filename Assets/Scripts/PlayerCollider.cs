using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public TrackController trackController;
    public GameController gameController;
    public int healthPoint;
    public Animator animator;

    public Cinemachine.CinemachineCollisionImpulseSource MyInpulse;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            healthPoint -= 1;
            if (healthPoint <= 0)
            {
                animator.SetTrigger("die");
                trackController.OnEnd();
                MyInpulse.GenerateImpulse();
            }
        }
    }
}
