using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Cinemachine.CinemachineCollisionImpulseSource MyInpulse;
    // Start is called before the first frame update
    void Start()
    {
        MyInpulse = GetComponent<Cinemachine.CinemachineCollisionImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            MyInpulse.GenerateImpulse();
            Destroy(gameObject);
        }
    }
}
