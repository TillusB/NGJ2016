﻿using UnityEngine;
using System.Collections;

public class Bunny : MonoBehaviour {
    public int speed = 1;
    public float jumpforce = 15;
    float horizontalInput = 0;
    float jumpInput = 0;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");
        if ( jumpInput != 0)
        {
            jump();
        }
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (horizontalInput != 0)
        {
            rb.velocity = movement;
        }
    }

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
}