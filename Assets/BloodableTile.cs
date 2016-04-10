using UnityEngine;
using System.Collections;

public class BloodableTile : MonoBehaviour {

	[SerializeField] SpriteRenderer bloodDecalSR;

	[SerializeField] Sprite sprite1;
	[SerializeField] Sprite sprite2;
	[SerializeField] Sprite sprite3;
//	bool isBlooded = false;

	float bloodAmount = 0;

	public void HitByBlood(float bloodPower){
//		Debug.Log("HitByBlood! - bloodCount: " + bloodCount);
		if (!bloodDecalSR.enabled) bloodDecalSR.enabled = true;
		bloodAmount += bloodPower;

		if (bloodAmount < 6000){
			bloodDecalSR.sprite = sprite1;
		}else if (bloodAmount < 20000){
			bloodDecalSR.sprite = sprite2;
		}else{
			bloodDecalSR.sprite = sprite3;
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
