using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BunnyBoost : MonoBehaviour {

	[SerializeField] BloodSpurter bloodSpurter;
	[SerializeField] float boostSpeed;
	[SerializeField] float boostBloodLose;

	Camera mainCam;
	Rigidbody2D rb;

	void Awake(){
		rb = GetComponent<Rigidbody2D>();
		mainCam = Camera.main;
	}

	void Update(){
		if (Input.GetMouseButton(0)){
			Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
			Vector2 dir = mousePos - (Vector2)transform.position;

			bloodSpurter.Boosting();

			rb.AddForce(-dir * boostSpeed);

			//Todo lose blood
		}
	}

	public void EnableBoost(bool on){
		enabled = on;
	}
}
