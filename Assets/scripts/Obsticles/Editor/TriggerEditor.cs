//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2014 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Trigger))]
public class UIButtonEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector();
		Trigger trigger = target as Trigger;
		GUILayout.BeginVertical(GUI.skin.box);
		GUILayout.Label("OnEnter");
		EventDelegateEditor.Field(trigger as Object, trigger.onEnter, "","");
		GUILayout.EndVertical();
		GUILayout.BeginVertical(GUI.skin.box);
		GUILayout.Label("OnExit");
		EventDelegateEditor.Field(trigger as Object, trigger.onExit, "","");
		GUILayout.EndVertical();
	}

	enum Highlight
	{
		DoNothing,
		Press,
	}
}
