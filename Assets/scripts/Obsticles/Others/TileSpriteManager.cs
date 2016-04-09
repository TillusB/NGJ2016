using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileSpriteManager : MonoBehaviour {

	public static TileSpriteManager ourInstance = null;

	public List<TileSpriteSwapper> spriteSwapers = new List<TileSpriteSwapper>();

	public static TileSpriteManager GetInstance()
	{
		if(ourInstance == null)
		{
			GameObject temp = new GameObject("TimeSpriteManager");
			ourInstance = temp.AddComponent<TileSpriteManager>();
		}
		return ourInstance;
	}

	public void AddSwapper(TileSpriteSwapper swapper)
	{
		if(!spriteSwapers.Contains(swapper))
			spriteSwapers.Add(swapper);
	}

	// Use this for initialization
	void Start () {
		if(ourInstance != null &&  ourInstance != this)
		{
			Destroy(gameObject);
			return;
		}
		ourInstance = this;
	}

	public void UpdateSprites(int worldState)
	{
		Debug.LogError(worldState.ToString());
		for(int index = 0; index < spriteSwapers.Count; index++)
		{
			spriteSwapers[index].StartSwapTo(worldState);
		}
	}
}
