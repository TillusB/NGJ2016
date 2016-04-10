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
    public BunnyAnimationController BunnyAnimController;
    public GameHandler gameHandler;

	public BloodSpurter bloodSpurter;
	public BunnyBoost bunnyBoost;
	bool hasDied = false;

    private bool _doJumpUntilAllowed = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        BunnyAnimController = transform.FindChild("BunnySprite").GetComponent<BunnyAnimationController>();
        health = FullHealth;
        GameCamera.instance.Start();

	}

	// Update is called once per frame
	void Update () {
        if (!gameHandler.GameIsStarted())
            return;

        if(health <= 0)
        {
            bunnyDie();
        }
        
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    public Vector2 currentMovment;
    void FixedUpdate()
    {
        if (!gameHandler.GameIsStarted())
            return;

        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");
        if ( jumpInput != 0 || _doJumpUntilAllowed)
        {
            jump();
        }

        bool OnGroundTest = isOnGround();

        if(OnGroundTest != OnGround && VelocityLastFrame.y <0)
        {
//            GameCamera.instance.SmallShake();
        }
        OnGround = OnGroundTest;
        VelocityLastFrame = rb.velocity;


        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (horizontalInput != 0)
        {
            rb.velocity = movement;
        }
        currentMovment = movement;
    }


    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void jump()
    {
        if (isOnGround())
        {
            bool isAllowedToJump = BunnyAnimController.IsAllowedToJump();
//            if(isAllowedToJump)
//            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpforce, 0));
                BunnyAnimController.DoJump();
                _doJumpUntilAllowed = false;
//            }
//            else
//            {
//                _doJumpUntilAllowed = true;
//            }
        }
    }

    public bool isOnGround()
    {
		int layerMask = 1 << LayerMask.NameToLayer("Default");

//		Debug.Log("LayerMask.NameToLayer(\"Default\"): " + LayerMask.NameToLayer("Default")+ ", layerMask: " +layerMask);

        bool onGround = true;
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - (GetComponent<CircleCollider2D>().radius+0.01f)), Vector2.down, 0.01f, layerMask);
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

		if(!hasDied)
		{
			hasDied = true;
			BunnyAnimationController.instance.PlayKillExplode();
		}
        //play death animation
        //end game
    }

    public float getHealth()
    {
        return health;
    }
}
