using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeactivateTimed : MonoBehaviour {
	public float time;
	public List<MonoBehaviour> toDeactivate = new List<MonoBehaviour>();
	public List<Collider2D> toDeactivateCollider2D = new List<Collider2D>();
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if(time < 0)
		{
			for(int index = 0; index < toDeactivate.Count; index++)
			{
				toDeactivate[index].enabled = false;
			}
			for(int index = 0; index < toDeactivateCollider2D.Count; index++)
			{
				toDeactivateCollider2D[index].enabled = false;
			}
			enabled = false;
		}
	}
}
