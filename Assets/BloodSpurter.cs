using UnityEngine;
using System.Collections;

public class BloodSpurter : MonoBehaviour {

	[Header("Prefab")]
	[SerializeField] BloodSpurtBall bloodSpurtBallPrefab;

	[Header("Variables")]
	[SerializeField] float ballLifetime;
	[SerializeField] float ballSpeed;
	[SerializeField] float ballTimeInterval;

	[SerializeField] float spurtInterval;
	[SerializeField] ParticleSystem spurtSystem;
	[SerializeField] ParticleSystem boostSystem;


	public bool isBleeding = false;

	private float nextBallTime;
	private float nextSpurtTime;

	void Update () {
		if (isBleeding){
			if (Time.time > nextBallTime){
				SpawnBloodBall();
				nextBallTime = Time.time + ballTimeInterval;
			}
			if (Time.time > nextSpurtTime){

				nextSpurtTime = Time.time + spurtInterval;

//				ParticleSystem.Burst burst = new ParticleSystem.Burst(Time.time, 10);
//				spurtSystem.emission.SetBursts(new ParticleSystem.Burst[]{burst});

				spurtSystem.Play();
//				spurtSystem.emission.SetBursts()
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


	public void Boosting(){
		boostSystem.Play();
	}
}
