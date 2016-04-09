using UnityEngine;
using System.Collections;

public class GameFinishController : MonoBehaviour {

    public GameHandler gameHandler;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
        
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision enter!");
//        Debug.Break();

        gameHandler.GameFinished();
    }
}
