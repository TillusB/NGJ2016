using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObsticleMover : MonoBehaviour {

	public List<Vector3> pathPoints = new List<Vector3>();
	public List<Transform> objs = new List<Transform>();
	public bool loop = true;
	public float speed = 1.0f;
	float totalTime = 0.1f;
	float time = -1.0f;
	int movingAt = 0;
	[System.NonSerialized]
	bool movingUp = true;

	void Start()
	{
		if(pathPoints.Count > 1)
		{
			totalTime = (pathPoints[0] - pathPoints[1]).magnitude / speed;
			time = 0;
		}
	}

	void Update ()
	{
		if(time >= 0)
		{
			time += Time.deltaTime;
			if(time > totalTime)
			{
				time -= totalTime;
				if(movingUp)
				{
					movingAt++;
					if(movingAt + 1 == pathPoints.Count)
					{
						movingAt = pathPoints.Count - 1;
						movingUp = false;
						totalTime = (pathPoints[movingAt] - pathPoints[movingAt-1]).magnitude / speed;//use modulu %
					}
					else
						totalTime = (pathPoints[movingAt] - pathPoints[movingAt+1]).magnitude / speed;
				}
				else
				{
					movingAt--;
					if(movingAt == 0)
					{
						movingAt = 0;
						movingUp = true;
						totalTime = (pathPoints[movingAt] - pathPoints[movingAt+1]).magnitude / speed;
					}
					else
						totalTime = (pathPoints[movingAt] - pathPoints[movingAt-1]).magnitude / speed;
				}
			}
			if(movingUp)
				SetPos(Vector3.Lerp(pathPoints[movingAt], pathPoints[movingAt+1], time/totalTime));
			else
				SetPos(Vector3.Lerp(pathPoints[movingAt], pathPoints[movingAt-1], time/totalTime));
		}
	}

	void SetPos(Vector3 pos)
	{
		transform.localPosition = pos;
		for(int index = 0; index < objs.Count; index++)
		{
			objs[index].localPosition = pos;
		}
	}

	#if UNITY_EDITOR
	public void OnDrawGizmos()
	{
		for(int index = 0; index < pathPoints.Count; index++)
		{
			Gizmos.DrawSphere(pathPoints[index] + transform.parent.position, 0.2f);
		}
	}
	#endif
}
