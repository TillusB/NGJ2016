using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnableWith : MonoBehaviour {

	public List<MonoBehaviour> toEnable;
	public List<Collider> toEnableColliders;
	public List<Collider2D> toEnableColliders2D;

	public void Enable()
	{
		for(int index = 0; index < toEnable.Count; index++)
		{
			toEnable[index].enabled = true;
		}
		for(int index = 0; index < toEnableColliders.Count; index++)
		{
			toEnableColliders[index].enabled = true;
		}
		for(int index = 0; index < toEnableColliders2D.Count; index++)
		{
			toEnableColliders2D[index].enabled = true;
		}

	}

}
