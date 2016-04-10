using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillerAreaManager : MonoBehaviour {
	
	static KillerAreaManager ourInstance;

	public GameObject player;
	public Bunny bunny;

	public Camera mainCam;

	public Gradient colors;
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

	void Update()
	{
		if(mainCam == null)
			mainCam = Camera.main;
		if(mainCam != null)
			mainCam.backgroundColor = colors.Evaluate(1 - bunny.getHealth() / 100.0f);
	}

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
		if(mainCam == null)
			mainCam = Camera.main;
	}

    public void DamagePlayer(float damage, DamageType aDamageType = DamageType.Normal)
	{
        if( bunny.getHealth() <= 0)
        {
            return;
        }
		bunny.reduceHealth(damage);
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
