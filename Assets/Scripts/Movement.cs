using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private Animator animate;
    private object flipped;

    public static bool hidden;

    public int keys = 0;

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

        }
        
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, gameObject.transform.position.y);
        completeflip();
    }

    /*void flip()
    {
        if (rb.velocity.x > 0)
        {
            SpriteRenderer_.flipX = false;
        }
        else if (rb.velocity.x < 0)
        {
            SpriteRenderer_.flipX = true;
        }
    }*/

    void completeflip()
    {
       /*flipped = gameObject.GetComponent<Transform>();
        flipped.Rotate(Vector2.up * speed);*/

       if (Input.GetKeyDown(KeyCode.D))
       {
            transform.eulerAngles = new Vector3(0, 0, 0);
       } 

       else if (Input.GetKeyDown(KeyCode.A))
       {
            transform.eulerAngles = new Vector3(0, 180, 0);
       }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Key"))
        {
            Destroy(collision.gameObject);
            keys = keys + 1;
        }
    }
}

