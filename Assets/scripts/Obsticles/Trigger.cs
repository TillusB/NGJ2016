using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour {

	static public Collider lastHit;
	static public Collider2D lastHit2D;

	public List<EventDelegate> onEnter = new List<EventDelegate>();
	public List<EventDelegate> onExit = new List<EventDelegate>();

	void OnTriggerExit(Collider other)
	{
		lastHit = other;
		lastHit2D = null;
		EventDelegate.Execute(onExit);
	}
	void OnTriggerExit2D(Collider2D other)
	{
		lastHit2D = other;
		lastHit = null;
		EventDelegate.Execute(onExit);
	}

	void OnTriggerEnter(Collider other)
	{
		lastHit = other;
		lastHit2D = null;
		EventDelegate.Execute(onEnter);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		lastHit2D = other;
		lastHit = null;
		EventDelegate.Execute(onEnter);
	}

	void OnTriggerStay2D(Collider2D other)
	{
	}
	void OnTriggerStay(Collider other)
	{
	}
}
