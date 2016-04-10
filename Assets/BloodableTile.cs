using UnityEngine;
using System.Collections;

public class BloodableTile : MonoBehaviour {

	[SerializeField] SpriteRenderer bloodDecalSR;

	[SerializeField] Sprite sprite1;
	[SerializeField] Sprite sprite2;
	[SerializeField] Sprite sprite3;
//	bool isBlooded = false;

	int bloodCount = 0;

	public void HitByBlood(){
//		Debug.Log("HitByBlood! - bloodCount: " + bloodCount);
		if (!bloodDecalSR.enabled) bloodDecalSR.enabled = true;
		bloodCount++;

		if (bloodCount < 20){
			bloodDecalSR.sprite = sprite1;
		}else if (bloodCount < 80){
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
