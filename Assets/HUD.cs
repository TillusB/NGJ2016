using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public GameObject player;
    public Bunny bunny;
    UnityEngine.UI.Slider healthBar;
	// Use this for initialization
	void Start () {
        healthBar = gameObject.GetComponent<UnityEngine.UI.Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = bunny.getHealth();
	}
}
