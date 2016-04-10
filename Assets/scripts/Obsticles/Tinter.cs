using UnityEngine;
using System.Collections;

public class Tinter : MonoBehaviour {

	public Gradient colors;

	public MeshRenderer renderer;
	
	// Update is called once per frame
	void Update () {
		renderer.material.color = colors.Evaluate(KillerAreaManager.GetInstance().bunny.getHealth() / 100.0f);
	}
}
