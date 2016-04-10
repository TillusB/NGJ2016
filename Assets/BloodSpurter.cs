using UnityEngine;
using System.Collections;

public class BloodSpurter : MonoBehaviour {

	[Header("Prefab")]
	[SerializeField] BloodSpurtBall bloodSpurtBallPrefab;

	[Header("Variables")]
	[SerializeField] float ballLifetime;
//	[SerializeField] float ballSpeed;
	[SerializeField] float ballTimeInterval;

	[SerializeField] float spurtInterval;
	[SerializeField] ParticleSystem spurtSystem;
	[SerializeField] ParticleSystem boostSystem;


	public bool isBleeding = false;

	private float nextBallTime;
	private float nextSpurtTime;



	void Update () {
		if (isBleeding){
//			if (Time.time > nextBallTime){
//				SpawnBloodBall();
//				nextBallTime = Time.time + ballTimeInterval;
//			}
			if (Time.time > nextSpurtTime){

				nextSpurtTime = Time.time + spurtInterval;

//				ParticleSystem.Burst burst = new ParticleSystem.Burst(Time.time, 10);
//				spurtSystem.emission.SetBursts(new ParticleSystem.Burst[]{burst});

				spurtSystem.Play();

				SpawnBloodBall(transform.forward, 4f);

//				spurtSystem.emission.SetBursts()
			}
		}
	}


	private void SpawnBloodBall(Vector3 dir, float ballSpeed){
		BloodSpurtBall bloodBall = Instantiate<BloodSpurtBall>(bloodSpurtBallPrefab);
		bloodBall.transform.position = transform.position;
		bloodBall.Init(dir, ballLifetime, ballSpeed);
	}

	public void StartBleeding(){
		isBleeding = true;
	}


	public void Boosting(){
		boostSystem.Play();

//		Debug.Log("boostSystem.transform.forward: " + boostSystem.transform.forward);
//		
//		Debug.Log("LookRotation: " + Quaternion.LookRotation(boostSystem.transform.forward));
//		Debug.Log("rotation * Vector3.forward: " + boostSystem.transform.rotation * Vector3.forward);
//		Debug.Log("rotation * Vector3.up: " + boostSystem.transform.rotation * Vector3.up);
//		Debug.Log("rotation * Vector3.right: " + boostSystem.transform.rotation * Vector3.right);
		SpawnBloodBall(boostSystem.transform.rotation * Vector3.right, 9f);

	}
}
