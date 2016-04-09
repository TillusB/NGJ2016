using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillerAreaManager : MonoBehaviour {

	static KillerAreaManager ourInstance;

	public GameObject player;
	public Bunny bunny;

	static public KillerAreaManager GetInstance()
	{
		return ourInstance;
	}

	public List<KillerArea> areas = new List<KillerArea>();

    public enum DamageType
    {
        Normal,
        SpikesDamage
    };

	// Use this for initialization
	void Start () {
		if(ourInstance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
			ourInstance = this;
		player = GameObject.Find("Bunny");
		bunny = player.GetComponent<Bunny>();
	}

    public void DamagePlayer(float damage, DamageType aDamageType = DamageType.Normal)
	{
		bunny.reduceHealth(damage);
        if( bunny.getHealth() < 0)
        {
            if(aDamageType == DamageType.SpikesDamage)
            {
                BunnyAnimationController.instance.PlayKillExplode();
            }
        }
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
