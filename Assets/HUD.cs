using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    GameObject player;
    Bunny bunny;
    public UnityEngine.UI.Slider healthBar;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Bunny");
        bunny = player.GetComponent<Bunny>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = bunny.getHealth();
	}
}
