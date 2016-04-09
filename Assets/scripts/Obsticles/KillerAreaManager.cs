using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillerAreaManager : MonoBehaviour {

	static KillerAreaManager ourInstance;

	public GameObject player;

	static public KillerAreaManager GetInstance()
	{
		return ourInstance;
	}

	public List<KillerArea> areas = new List<KillerArea>();

	// Use this for initialization
	void Awake () {
		if(ourInstance != null)
		{
			Destroy(gameObject);
		}
		else
			ourInstance = this;
	}

	public void DamagePlayer(float damage)
	{
		
	}

	public void AddKillerArea(KillerArea area)
	{
		if(!areas.Contains(area))
		{
			areas.Add(area);
		}
	}

	public void RemoveKillerArea(KillerArea area)
	{
		areas.Remove(area);
	}
}
