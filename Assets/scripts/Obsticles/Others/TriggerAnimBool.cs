using UnityEngine;
using System.Collections;

public class TriggerAnimBool : MonoBehaviour {

	public Animator anim;
	public string animName;

	public void TriggerBool()
	{
		anim.SetBool(animName, true);
	}
}
