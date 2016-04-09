using UnityEngine;
using System.Collections;

public class KillerRock : MonoBehaviour {
	bool hasStartedFaling = false;
	bool canFall = false;
	public float damage = 5;
	public GameObject boulder;
	public Rigidbody2D boulderBody;
	public CircleCollider2D boulderCollider;
	public Gate gate;
	public void StartFalling()
	{
		if(!hasStartedFaling)
		{
			gate.Open(() =>
			{
				DoorOpen();
			});
			hasStartedFaling = true;
		}
	}

	public void DoorOpen()
	{
		canFall = true;
		boulderBody.constraints = RigidbodyConstraints2D.None;
	}

	public void HitSomething()
	{
		if(Trigger.lastHit2D != null)
		{
			if(Trigger.lastHit2D.transform.IsChildOf(KillerAreaManager.GetInstance().player.transform)
			   || Trigger.lastHit2D.transform == KillerAreaManager.GetInstance().player.transform)
			{
				if(KillerAreaManager.GetInstance().player.transform.position.y < boulder.transform.position.y)
				{
					KillerAreaManager.GetInstance().DamagePlayer(damage);
				}
			}
		}
	}

	public void Update()
	{
		if(Extension.IsOnGround(boulderCollider))
		{
			boulderBody.constraints = RigidbodyConstraints2D.FreezeAll;
			boulderBody.isKinematic = true;
			boulderCollider.isTrigger = false;
			boulderCollider.gameObject.layer = LayerMask.NameToLayer("Default");
			enabled = false;
		}
	}
}
