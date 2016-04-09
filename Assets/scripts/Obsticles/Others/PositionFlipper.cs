using UnityEngine;
using System.Collections;

public class PositionFlipper : MonoBehaviour {

	Vector3 prevPos;

	void Start()
	{
		prevPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.x < prevPos.x)
			transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
		else
			transform.rotation = Quaternion.identity;
		prevPos = transform.position;
	}
}
