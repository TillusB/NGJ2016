using UnityEngine;
using System.Collections;

public class BunnyAnimationController : MonoBehaviour {

    Bunny BunnyScript;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
	// Use this for initialization
	void Start () 
    {
        BunnyScript = transform.parent.GetComponent<Bunny>();
        sr =  GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( BunnyScript.rb.velocity.x > 0 )
        {
            sr.flipX = false;
            anim.Play("bunny_run");

        }
        else if( BunnyScript.rb.velocity.x < 0 )
        {
            sr.flipX = true;
            anim.Play("bunny_run");
        }
        else
        {
            anim.Play("bunny_idle");
        }

        float animSpeed = Mathf.Abs( BunnyScript.rb.velocity.x/3f );
        anim.speed = animSpeed;
	}
}
