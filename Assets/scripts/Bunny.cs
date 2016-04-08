using UnityEngine;
using System.Collections;

public class Bunny : MonoBehaviour {
    public int speed = 1;
    public float jumpforce = 15;
    float horizontalInput = 0;
    bool OnGround = true;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0){
            transform.Translate(new Vector3(speed * horizontalInput, 0, 0));
        }
        if(Input.GetAxis("Jump") != 0)
        {
            jump();
        }
        Debug.Log(horizontalInput);


        bool OnGroundTest = isOnGround();
        if(OnGroundTest != OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.y <0)
        {
            GameCamera.instance.Shake();
        }
        OnGround = OnGroundTest;

	}

    public void setSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    private void jump()
    {
        Debug.Log("Jump!");
        if (isOnGround())
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpforce, 0));
        }
    }
    
    private bool isOnGround()
    {
        bool onGround = true;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - (GetComponent<CircleCollider2D>().radius+0.1f)), Vector2.down, 0.01f);
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
