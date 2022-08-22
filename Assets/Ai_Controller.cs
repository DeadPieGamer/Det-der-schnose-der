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


    Transform playerPosition;
    Transform lastPlayerPosition;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        float distanceX = transform.position.x - playerPosition.position.x;

        if (distanceX < playerPosition.position.x)
        {
            rightDirection = true;
        }
        else
        {
            rightDirection = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 10);
        Debug.DrawRay(transform.position, -transform.right,Color.red, 1);

        if(hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                enemyState = EnemyState.chasing;
            }
        }
       

        effektDistanceMathf();

        if (enemyState == EnemyState.roaming)
        {

            if (rightDirection)
            {


                rb.velocity = new Vector2(speed, transform.position.y);
                transform.eulerAngles = new Vector3(0, 180, 0); // Flipped


            }
            else
            {
                rb.velocity = new Vector2(-speed, transform.position.y);
                transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
            }


        }
        

        else if (enemyState == EnemyState.searching)
        {
            
        }
        else if (enemyState == EnemyState.chasing)
        {

        }
        else if (enemyState == EnemyState.catching)
        {

        }







    }

    void effektDistanceMathf()
    {
        float distance = Vector2.Distance(transform.position, playerPosition.position);
        if (distance < 40)
        {
            MonsterEffect.monsterIsNear = true;
        }
        else
        {
            MonsterEffect.monsterIsNear = false;
        }
        if (distance >= 70)
        {
            Destroy(gameObject);
        }
    }
    
}
