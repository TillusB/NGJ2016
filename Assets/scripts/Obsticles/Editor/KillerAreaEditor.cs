using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(KillerArea))]
public class KillerAreaEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
	}

	

}
