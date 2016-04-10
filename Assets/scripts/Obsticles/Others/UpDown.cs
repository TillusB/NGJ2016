using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {

	public AnimationCurve curve;

	Vector3 startPos;
	float loopVal = 0.0f;
	bool goingUp = true;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(goingUp)
			loopVal += Time.deltaTime;
		else
			loopVal -= Time.deltaTime;
		if(loopVal > 1.0f)
		{
			loopVal = 1.0f;
			goingUp = false;
		}
		else if(loopVal < 0.0f)
		{
			goingUp = true;
			loopVal = 0.0f;
		}
		transform.position = startPos + new Vector3(0,curve.Evaluate(loopVal) -0.5f,0);
	}
}
