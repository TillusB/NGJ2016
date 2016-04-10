using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BloodSpurtBall : MonoBehaviour {

	private float deathTime;

	private Rigidbody2D rb;

	int defaultLayerMask;

	float bloodPower;

	void Awake(){
		rb = GetComponent<Rigidbody2D>();

		defaultLayerMask = 1 << LayerMask.NameToLayer("Default");
	}

	public void Init(Vector3 dir, float lifetime, float speed, float bloodPower){
		deathTime = Time.time + lifetime;
		this.bloodPower = bloodPower;
//		Debug.Log("dir * speed: " + (dir * speed));
//		dir 
		dir.x += Random.Range(-0.1f, 0.1f);
		dir.y += Random.Range(-0.1f, 0.1f);
		if (rb == null) rb = GetComponent<Rigidbody2D>();
		rb.AddForce(dir * speed, ForceMode2D.Impulse);
	}


	void Update(){
		if (Time.time > deathTime){
			Destroy(gameObject);
		}	


		Collider2D groundColl = Physics2D.OverlapCircle(transform.position, 0.1f, defaultLayerMask);
		if (groundColl != null && groundColl.GetComponent<BloodableTile>() != null) groundColl.GetComponent<BloodableTile>().HitByBlood(bloodPower);
	
//		if (groundColl)
	}

}
