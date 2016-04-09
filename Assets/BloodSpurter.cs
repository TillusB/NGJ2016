using UnityEngine;
using System.Collections;

public class BloodSpurter : MonoBehaviour {

	[Header("Prefab")]
	[SerializeField] BloodSpurtBall bloodSpurtBallPrefab;

	[Header("Variables")]
	[SerializeField] float ballLifetime;
	[SerializeField] float ballSpeed;
	[SerializeField] float ballTimeInterval;


	public bool isBleeding = false;

	private float nextBallTime;

	void Update () {
		if (isBleeding){
			if (Time.time > nextBallTime){
				SpawnBloodBall();
				nextBallTime = Time.time + ballTimeInterval;
			}
		}
	}


	private void SpawnBloodBall(){
		BloodSpurtBall bloodBall = Instantiate<BloodSpurtBall>(bloodSpurtBallPrefab);
		bloodBall.transform.position = transform.position;
		bloodBall.Init(transform.forward, ballLifetime, ballSpeed);
	}

	public void StartBleeding(){
		//TODO
	}
}
