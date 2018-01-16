using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int score;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private int maxRange;
    [SerializeField]
    private int minRange;

    private Animator anim;
    private Rigidbody2D rb;
    private int times = 0;
    private bool lookRight = false;
    Renderer rnd;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rnd = GetComponent<Renderer>();
	}

    #region Health
    // Reduces health and checks if death
    void TakeDamage()
    {
        //reduce health;
        health--;
        //Play hurt sound
        if (health == 0)
        {
            //Call Death Method
            Death();
        }
    }

    //Play Death Animation,
    //Increase Score
    //Destroy Object
    void Death()
    {
        //Play Death Animation
        anim.SetTrigger("Die");
        //Increase Score
        ScoreManager.UpdateScore(score);
        //Destroy object
        Destroy(gameObject);
    }
    #endregion

    #region movement

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            if (times % 2 == 0)
            {
               // Flip();
            }
            times++;
           // transform.Translate(GetDirection() * Time.deltaTime * speed);
        }
        if (collision.collider.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Bullet")
        {
            TakeDamage();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //Debug.Log(Vector3.Distance(transform.position, target.position));
        if ((Vector3.Distance(transform.position, target.position) < maxRange)
            && (Vector3.Distance(transform.position, target.position) > minRange)) {
            //Debug.Log("Moving");
            Movement();
        }
	}
}
