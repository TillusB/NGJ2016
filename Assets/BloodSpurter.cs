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


	[SerializeField] Bunny bunny;
//	private float 

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

				float bloodPower = 100f - bunny.getHealth() + 10f;

				spurtSystem.emissionRate = bloodPower;
				boostSystem.emissionRate = bloodPower;
//				ParticleSystem.EmissionModule emMod = spurtSystem.emission;
//				ParticleSystem.MinMaxCurve minMaxCurve = emMod.rate;
//				minMaxCurve.curveScalar =  100f - bunny.getHealth();
//
//				spurtSystem.emission = emMod;
////				emMod.rate.curveScalar = 100f - bunny.getHealth();
////				minMaxCurve.curveScalar = 100 - bunny.getHealth();
//				spurtSystem.emission.rate = minMaxCurve;

				Debug.Log("spurtSystem.emission.rate.curveScalar)");

				spurtSystem.Play();

				

				SpawnBloodBall(transform.forward, 4f, bloodPower);

//				spurtSystem.emission.SetBursts()
			}
		}
	}


	private void SpawnBloodBall(Vector3 dir, float ballSpeed, float bloodPower){
		BloodSpurtBall bloodBall = Instantiate<BloodSpurtBall>(bloodSpurtBallPrefab);
		bloodBall.transform.position = transform.position;
		bloodBall.Init(dir, ballLifetime, ballSpeed, bloodPower);
	}

	public void StartBleeding(){
		isBleeding = true;
	}


	public void Boosting(){
		boostSystem.Play();

		float bloodPower = 100f - bunny.getHealth();

		bunny.reduceHealth(10f * Time.deltaTime);

//		Debug.Log("boostSystem.transform.forward: " + boostSystem.transform.forward);
//		
//		Debug.Log("LookRotation: " + Quaternion.LookRotation(boostSystem.transform.forward));
//		Debug.Log("rotation * Vector3.forward: " + boostSystem.transform.rotation * Vector3.forward);
//		Debug.Log("rotation * Vector3.up: " + boostSystem.transform.rotation * Vector3.up);
//		Debug.Log("rotation * Vector3.right: " + boostSystem.transform.rotation * Vector3.right);
		SpawnBloodBall(boostSystem.transform.rotation * Vector3.right, 9f, bloodPower);

	}
}
