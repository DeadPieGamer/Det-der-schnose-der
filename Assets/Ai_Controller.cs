using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    roaming, searching, chasing, catching 
}

public class Ai_Controller : MonoBehaviour
{

    public EnemyState enemyState;

    [SerializeField]
    float speed;

    [SerializeField]
    public bool rightDirection;
    bool fliped;

    Rigidbody2D rb;


    public Transform playerPosition;
    public Transform lastPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerPosition.position);
        print(distance);

        if (enemyState == EnemyState.roaming)
        {
            if (rightDirection)
            {
                if(distance < -20)
                {
                    rightDirection = false;
                }

                rb.velocity = new Vector2(speed, transform.position.y);
                transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
            }
            else
            {

                if (distance > 20)
                {
                    rightDirection = true;
                }

                rb.velocity = new Vector2(-speed, transform.position.y);

                transform.eulerAngles = new Vector3(0, 0, 0); // Normal

            }
        }


        else if(enemyState == EnemyState.searching)
        {

        }
        else if(enemyState == EnemyState.chasing)
        {

        }
        else if(enemyState == EnemyState.catching)
        {

        }
       






    }


}
