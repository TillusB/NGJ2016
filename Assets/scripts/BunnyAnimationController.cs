using UnityEngine;
using System.Collections;

public class BunnyAnimationController : MonoBehaviour {


    Bunny BunnyScript;
    SpriteRenderer sr;
    Animator anim;

    private static BunnyAnimationController _instance;

    public static BunnyAnimationController instance
    {
        get 
        {
            if(_instance == null)
            {
                _instance = GameObject.Find("Bunny").transform.GetChild(0).GetComponent<BunnyAnimationController>();
            }
            return _instance; 
        }

    }

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

        if(Input.GetKeyUp(KeyCode.K))
        {
            anim.Play("bunny_die");
        }
        if( IsPlaying("bunny_die"))
            return;

        if( BunnyScript.rb.velocity.x > 0 )
        {
            sr.flipX = false;

        }
        else if( BunnyScript.rb.velocity.x < 0 )
        {
            sr.flipX = true;
        }

        if(BunnyScript.isOnGround() )
            DoGroundAnimations();
        else
        {
            if(BunnyScript.rb.velocity.y<0)
            {
                anim.Play("bunny_jumpFall");
            }         
        }

    }
    void DoGroundAnimations()
    {
        if( BunnyScript.currentMovment.x > 0 )
        {
            anim.Play("bunny_run");

        }
        else if( BunnyScript.currentMovment.x < 0 )
        {
            anim.Play("bunny_run");
        }
        else
        {
            anim.Play("bunny_idle");
        }



        if( anim.GetCurrentAnimatorStateInfo(0).IsName("bunny_run"))
        {
            float animSpeed = Mathf.Abs( BunnyScript.rb.velocity.x/3f );
            anim.speed = animSpeed;
        }
        else
        {
            anim.speed = 1;
        } 
    }
    public bool IsPlaying(string aName)
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName(aName);
    }

    public void DoJump()
    {
        anim.Play("bunny_jump"); 
    }

    public bool IsAllowedToJump()
    {

        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1);
        if( anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 1f)
        if( anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 > 0.7f)
            return true;
        if( anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 0.2f)
            return true;

        return false;
    }
    public void PlayKillExplode()
    {
        anim.Play("bunny_die");
    }
}
