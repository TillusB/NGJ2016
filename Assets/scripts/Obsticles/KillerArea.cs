using UnityEngine;
using System.Collections;

public class KillerArea : MonoBehaviour {

	public float enterDamage = 5;
	public float stayDamage = 0;
	public float exitDamage = 0;

	public ExpellDirection expellType = ExpellDirection.NONE;

	public Vector3 expellPoint;
	public float duration = 0;
	public bool removeOnRealease = false;
	

	public enum ExpellDirection
	{
		NONE,
		OMNI,
		DIRECTION,
		TRAP_PLAYER,
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

	public void OnEnterDamage()
	{
		KillerAreaManager.GetInstance().DamagePlayer(enterDamage);
	}

	public void ExpellPlayer()
	{
		ExpellPlayer(KillerAreaManager.GetInstance().player.transform);
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
		else if(expellType == ExpellDirection.TRAP_PLAYER)
		{
			Rigidbody2D body = KillerAreaManager.GetInstance().bunny.GetComponent<Rigidbody2D>();
			body.constraints |= RigidbodyConstraints2D.FreezePosition;
			Invoke("ReleaseBunny", duration);
		}
	}

	public void ReleaseBunny()
	{
		Rigidbody2D body = KillerAreaManager.GetInstance().bunny.GetComponent<Rigidbody2D>();
		body.constraints = RigidbodyConstraints2D.FreezeRotation;
		if(removeOnRealease)
		{
			gameObject.SetActive(false);
		}
	}

	#if UNITY_EDITOR
	public void OnDrawGizmos()
	{
		Gizmos.DrawSphere(expellPoint + transform.position, 0.3f);
	}
	#endif
}
