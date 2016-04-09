using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gate : MonoBehaviour {
	[System.Serializable]
	public class DoorPart
	{
		public AnimationCurve zCurve;
		public GameObject obj;
		[System.NonSerialized]
		public float duration = 0;
		public float totalDuration;
	}
		
	public List<DoorPart> door;
	bool startOpening = false;
	bool isDone = false;

	System.Action doneCallback;
	
	// Update is called once per frame
	void Update () {
		if(startOpening && !isDone)
		{
			int done = 0;
			for(int index = 0; index < door.Count; index++)
			{
				door[index].duration += Time.deltaTime;
				if(door[index].duration > door[index].totalDuration)
				{
					done++;
					door[index].obj.transform.rotation = Quaternion.Euler(new Vector3(0,0, door[index].zCurve.Evaluate(1)));
				}
				else
				{
					door[index].obj.transform.rotation = Quaternion.Euler(new Vector3(0,0, door[index].zCurve.Evaluate(door[index].duration / door[index].totalDuration)));
				}
			}
			if(done == door.Count)
			{
				isDone = true;
				if(doneCallback != null)
					doneCallback();
			}
		}
	}

	public void Open(System.Action onComplete)
	{
		startOpening = true;
		doneCallback = onComplete;
	}
}
