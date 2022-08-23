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

    Rigidbody2D rb;


    Transform playerPosition;
    Transform lastPlayerPosition;
    float distance;
    float distanceX;

    AudioSource screams;

    // Start is called before the first frame update
    void Awake()
    {
        screams = gameObject.GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distanceX = transform.position.x - playerPosition.position.x;

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
        distance = Vector2.Distance(transform.position, playerPosition.position);
        screams.volume = distance / 20;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right, 10);
        Debug.DrawRay(transform.position, -transform.right,Color.red, 1);

        if(hit.collider != null)
        {
            if (hit.collider.tag == "Player" && Movement.hidden == false)
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
            speed = 7f;
            rb.velocity = new Vector2(0, 0);
           
            if(distance <= 4)
            {
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPosition.position.x, transform.position.y), speed * Time.deltaTime);

            }
        }
        else if (enemyState == EnemyState.catching)
        {

        }







    }

    void effektDistanceMathf()
    {
       
        if (distance < 30)
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
