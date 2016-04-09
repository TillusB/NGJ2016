using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	Camera mainCam;

	void Start(){
		mainCam = Camera.main;
	}

	void Update () {
		Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

		Vector2 dir = mousePos - (Vector2)transform.position;

		transform.rotation = Quaternion.LookRotation(dir);
	}
}
