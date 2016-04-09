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
		Invoke("Init", 0.1f);
	}

	/// <summary>
	/// Called by invoke.
	/// </summary>
	public void Init()
	{
		KillerAreaManager.GetInstance().AddKillerArea(this);
	}

	public void OnDissable()
	{
		KillerAreaManager.GetInstance().RemoveKillerArea(this);
	}

	void OnTriggerExit(Collider other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().player.transform) || other.transform == KillerAreaManager.GetInstance().player.transform)
		{
			KillerAreaManager.GetInstance().DamagePlayer(exitDamage);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().player.transform) || other.transform == KillerAreaManager.GetInstance().player.transform)
		{
			KillerAreaManager.GetInstance().DamagePlayer(exitDamage);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().player.transform) || other.transform == KillerAreaManager.GetInstance().player.transform)
		{
			KillerAreaManager.GetInstance().DamagePlayer(enterDamage);
		}
		ExpellPlayer(other.transform);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().player.transform) || other.transform == KillerAreaManager.GetInstance().player.transform)
		{
			KillerAreaManager.GetInstance().DamagePlayer(enterDamage);
		}
		ExpellPlayer(other.transform);
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().player.transform) || other.transform == KillerAreaManager.GetInstance().player.transform)
		{
			KillerAreaManager.GetInstance().DamagePlayer(stayDamage * Time.deltaTime);
		}
		ExpellPlayer(other.transform);
	}
	void OnTriggerStay(Collider other)
	{
		if(other.transform.IsChildOf(KillerAreaManager.GetInstance().player.transform) || other.transform == KillerAreaManager.GetInstance().player.transform)
		{
			KillerAreaManager.GetInstance().DamagePlayer(stayDamage * Time.deltaTime);
		}
		ExpellPlayer(other.transform);
	}

	public void ExpellPlayer(Transform playerPoint)
	{
		if(expellType == ExpellDirection.DIRECTION)
		{
			KillerAreaManager.GetInstance().bunny.ApplyForce(expellPoint);
		}
		else if(expellType == ExpellDirection.OMNI)
		{
			KillerAreaManager.GetInstance().bunny.ApplyForce((expellPoint - playerPoint.position).normalized);
		}
	}
	#if UNITY_EDITOR
	public void OnDrawGizmos()
	{
		Gizmos.DrawSphere(expellPoint + transform.position, 0.3f);
	}
	#endif
}
