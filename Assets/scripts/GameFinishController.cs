using UnityEngine;
using System.Collections;

public class GameFinishController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
        
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision enter!");
        Debug.Break();
    }
}
