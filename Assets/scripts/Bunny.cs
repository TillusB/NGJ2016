using UnityEngine;
using System.Collections;

public class Bunny : MonoBehaviour {
    public int speed = 1;
    public float jumpforce = 15;

    float horizontalInput = 0;
<<<<<<< HEAD
    bool OnGround = true;
	// Use this for initialization
	void Start () 
    {

=======
    float jumpInput = 0;
    private int health;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        health = 100;
>>>>>>> origin/master
	}
	
	// Update is called once per frame
	void Update () {
        if(health <= 0)
        {
            bunnyDie();
        }
	}

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");
        if ( jumpInput != 0)
        {
            jump();
        }
<<<<<<< HEAD
        Debug.Log(horizontalInput);


        bool OnGroundTest = isOnGround();
        if(OnGroundTest != OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.y <0)
        {
            GameCamera.instance.Shake();
        }
        OnGround = OnGroundTest;

	}
=======
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (horizontalInput != 0)
        {
            rb.velocity = movement;
        }
    }
>>>>>>> origin/master

    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    private void jump()
    {
        if (isOnGround())
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpforce, 0));
        }
    }
    
    private bool isOnGround()
    {
        bool onGround = true;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - (GetComponent<CircleCollider2D>().radius+0.01f)), Vector2.down, 0.01f);
        if (hit.transform != null && hit.rigidbody.gameObject.tag != "Player")
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        return onGround;
    }

    public void ApplyForce(Vector3 forceVector)
    {
        rb.AddForce(forceVector);
    }

    public void reduceHealth(int amount)
    {
        health -= amount;
    }

    private void bunnyDie()
    {
        speed = 0;
        jumpforce = 0;

        //play death animation
        //end game
    }
}
