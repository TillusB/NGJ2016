using UnityEngine;
using System.Collections;

public class KillerArea : MonoBehaviour {

	public float enterDamage = 5;
	public float stayDamage = 0;
	public float exitDamage = 0;

	public ExpellDirection expellType = ExpellDirection.NONE;

	public Vector3 expellPoint;
	

	public enum ExpellDirection
	{
		NONE,
		OMNI,
		DIRECTION,
		//PLANE,
	}

	public void OnEnable()
	{ 
		KillerAreaManager.GetInstance().AddKillerArea(this);
	}

	public void OnDissable()
	{
		KillerAreaManager.GetInstance().RemoveKillerArea(this);
	}

	void OnTriggerExit(Collider other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().gameObject.transform))
		{
			KillerAreaManager.GetInstance().DamagePlayer(exitDamage);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().gameObject.transform))
		{
			KillerAreaManager.GetInstance().DamagePlayer(enterDamage);
		}
		ExpellPlayer(other.transform);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().gameObject.transform))
		{
			KillerAreaManager.GetInstance().DamagePlayer(enterDamage);
		}
		ExpellPlayer(other.transform);
	}

	void OnTriggerStay(Collider other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().gameObject.transform))
		{
			KillerAreaManager.GetInstance().DamagePlayer(stayDamage * Time.deltaTime);
		}
		ExpellPlayer(other.transform);
	}

	public void ExpellPlayer(Transform playerPoint)
	{
		if(expellType == ExpellDirection.DIRECTION)
		{
			//KillerAreaManager.GetInstance().bunny.ApplyForce(expellPoint);
		}
		else if(expellType == ExpellDirection.OMNI)
		{
			//KillerAreaManager.GetInstance().bunny.ApplyForce((expellPoint - playerPoint.position).Normalized);
		}
	}
}
