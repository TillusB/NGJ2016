using UnityEngine;
using System.Collections;

public class BloodableTile : MonoBehaviour {

	[SerializeField] SpriteRenderer bloodDecalSR;

	bool isBlooded = false;

	public void HitByBlood(){
		if (!isBlooded){
			bloodDecalSR.enabled = true;
		}
	}

//	void OnTriggerEnter2D(Collider2D coll){
//		if (!isBlooded){
//			if (coll.gameObject.tag.Equals("BloodBall")){
//				bloodDecalSR.enabled = true;
//			}
//		}
//	}
}
