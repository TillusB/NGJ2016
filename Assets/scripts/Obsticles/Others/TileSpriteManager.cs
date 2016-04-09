using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileSpriteManager : MonoBehaviour {

	public static TileSpriteManager ourInstance = null;

	public List<TileSpriteSwapper> spriteSwapers = new List<TileSpriteSwapper>();

	public static TileSpriteManager GetInstance()
	{
		return ourInstance;
	}


	// Use this for initialization
	void Start () {
		if(ourInstance != null)
		{
			Destroy(gameObject);
			return;
		}
		ourInstance = this;
	}

	public void UpdateSprites(int worldState)
	{
		for(int index = 0; index < spriteSwapers.Count; index++)
		{
			spriteSwapers[index].StartSwapTo(worldState);
		}
	}
}
