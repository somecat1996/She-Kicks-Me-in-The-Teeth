using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBehavior : MonoBehaviour
{
    public int leftRange;
    public int rightRange;

    private float velocity;
    private float accleration;
    private Rigidbody2D rb;
    private GameController gm;

    private bool haveCreated = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity += accleration * Time.deltaTime;
        rb.velocity = Vector2.left * velocity;

        if (transform.position.x <= leftRange)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.x <= rightRange && !haveCreated)
        {
            gm.OnCreateTrack();
            haveCreated = true;
        }
    }

    public void OnInitial(float v, float a)
    {
        velocity = v;
        accleration = a;
        rb.velocity = Vector2.left * velocity;
    }
}
