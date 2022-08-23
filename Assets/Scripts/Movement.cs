using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    public static bool hidden;


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
        if (hidden)
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (!hidden)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6;
            }
            else
            {
                speed = 4;
            }

            float horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontal * speed, gameObject.transform.position.y);
            flip();
        }
        

    
    }

    void flip()
    {
        if (rb.velocity.x > 0)
        {
            SpriteRenderer_.flipX = false;
        }
        else if (rb.velocity.x < 0)
        {
            SpriteRenderer_.flipX = true;

        }
    }
}
