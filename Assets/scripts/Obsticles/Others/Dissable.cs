using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dissable : MonoBehaviour {

	public List<MonoBehaviour> dissabled;
	public List<Collider2D> dissableCollider;

	public void TriggerDissable()
	{
		for(int index = 0; index < dissabled.Count; index++)
		{
			dissabled[index].enabled = false;
		}
		for(int index = 0; index < dissableCollider.Count; index++)
		{
			dissableCollider[index].enabled = false;
		}
	}
}
