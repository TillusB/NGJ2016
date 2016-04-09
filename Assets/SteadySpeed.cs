using UnityEngine;
using System.Collections;

public class SteadySpeed : MonoBehaviour {

	[SerializeField] Vector3 velocity;
	
	// Update is called once per frame
	void Update () {
		transform.position += velocity * Time.deltaTime;
	}
}
