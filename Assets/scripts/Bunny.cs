using UnityEngine;
using System.Collections;

public class Bunny : MonoBehaviour {
    public const int FullHealth = 100;

    public float speed = 5;
    public float jumpforce = 15;

    float horizontalInput = 0;
    bool OnGround = true;
    Vector2 VelocityLastFrame = Vector2.zero;

    float jumpInput = 0;
    private float health;

    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        health = FullHealth;
        GameCamera.instance.Start();
	}

	// Update is called once per frame
	void Update () {
        if(health <= 0)
        {
            bunnyDie();
        }
        #if UNITY_EDITOR //DEBUG
                if (Input.GetKeyDown("a"))
                {
                    reduceHealth(10);
                    Debug.Log(health);
                }
        #endif
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");
        if ( jumpInput != 0)
        {
            jump();
        }

        bool OnGroundTest = isOnGround();

        if(OnGroundTest != OnGround && VelocityLastFrame.y <0)
        {
            GameCamera.instance.SmallShake();
        }
        OnGround = OnGroundTest;
        VelocityLastFrame = rb.velocity;


        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (horizontalInput != 0)
        {
            rb.velocity = movement;
        }
    }


    public void setSpeed(float newSpeed)
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
        if (hit.transform != null && hit.collider.gameObject.tag != "Player")
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

    public void reduceHealth(float amount)
    {
        health -= amount;
        if (health < 0)
            health = 0;
    }

    public void increaseHealth(float amount)
    {
        health += amount;
        if (health > 100)
            health = 100;
    }

    public void ResurrectBunny()
    {
        speed = 5;
        jumpforce = 15;

        health = FullHealth;
    }

    private void bunnyDie()
    {
        Debug.Log("DIE BUNNY, DIE!");
        speed = 0;
        jumpforce = 0;

        //play death animation
        //end game
    }

    public float getHealth()
    {
        return health;
    }
}
