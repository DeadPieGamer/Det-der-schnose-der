using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;



    SpriteRenderer SpriteRenderer_;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer_ = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        flip();
    }

    void flip()
    {
        if (rb.velocity.x < 0)
        {
            SpriteRenderer_.flipX = false;
        }
        else if (rb.velocity.x > 0)
        {
            SpriteRenderer_.flipX = true;

        }
    }
}
