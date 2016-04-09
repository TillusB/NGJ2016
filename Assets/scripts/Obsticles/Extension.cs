using UnityEngine;
using System.Collections;

public static class Extension {
	public static Vector2 xy(this Vector3 vector)
	{
		return new Vector2(vector.x, vector.y);
	}

	static public bool IsOnGround(CircleCollider2D collider)
	{
		bool onGround = true;
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(collider.transform.position.x, collider.transform.position.y - (collider.radius+0.01f)), Vector2.down, 0.01f);
		if (hit.transform != null && hit.collider.gameObject.tag != "Player")
		{
			onGround = true;
		}
		else
		{
			onGround = false;
		}
		return onGround;
	}

}
