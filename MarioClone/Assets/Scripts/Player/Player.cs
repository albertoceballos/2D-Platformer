using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool grounded;
    [SerializeField]
    private float speed = 4.0f;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shooter;
    [SerializeField]
    private float cooldown;

    private int health;
    private bool lookRight;
    private Rigidbody2D rb;
    private bool canShot = true;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        lookRight = true;
        health = 3;
	}

    #region movement

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (move > 0)
        {
            rb.velocity = new Vector2(speed * move, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed * move, rb.velocity.y);
        }
        if (move > 0 && !lookRight) Flip();
        if (move < 0 && lookRight) Flip();
        if (Input.GetKey("w"))
        {
            Jump();
        }
        if (Input.GetKey("k") && grounded && canShot)
        {
            Debug.Log("Shoot");
            Shoot();
        }
    }

    // Change Directoin
    void Flip()
    {
        //Set lookright variable to the opposite
        lookRight = !lookRight;
        //change direction
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    //allows the player to jump
    void Jump()
    {
        if (grounded) //if the player is not in the air then jump
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); //adds force to enable jump
            //anim.SetBool("Jump", true); //play jump animation
            grounded = false; //set grounded to false
        }
    }

    #endregion

    #region health

    //takes health from player
    void TakeDamage()
    {
        health--;
        //Play hurt sound and flash sprite
        Debug.Log("Health=" + health);
        if (health == 0)
        {
            //if health is zero call death method
            Death();
        }
    }

    //player died
    void Death()
    {
        //anim.SetTrigger("Die"); //play death animation
        Destroy(gameObject); //destroy player object
        GameManagerScript.GameOver(); //GameOver
        Debug.Log("You died");
    }

    #endregion

    #region attack
    void Shoot()
    {
        //Debug.Log("Shot bullet");
        GameObject bt = Instantiate(bullet,shooter.position,shooter.rotation);
        Bullet sc = bt.GetComponent<Bullet>();
        if (lookRight)
        {
            sc.speed *= 1;
        }
        else
        {
            sc.speed *= -1;
        }
        StartCoroutine(CanShoot());
    }

    IEnumerator CanShoot()
    {
        canShot = false;
        yield return new WaitForSeconds(cooldown);
        canShot = true;
    }
#endregion

    //Check for collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy") //collided with enemy object
        {
            //call take damage function
            TakeDamage();
        }
        if (collision.collider.tag == "Ground") //is grounded
        {
            grounded = true;
        }
    }

    void FixedUpdate()
    {
        Movement();
    }
}
