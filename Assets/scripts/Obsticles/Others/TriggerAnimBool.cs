using UnityEngine;
using System.Collections;

public class TriggerAnimBool : MonoBehaviour {

	public Animator anim;
	public string animName;

	public void TriggerBool()
	{
		Debug.LogError("Triggered");
		anim.SetBool(animName, true);
	}
}
