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
		Invoke("ChangeSprites", 0.5f);
	}

	void Update()
	{
		float percentage = 1.0f - KillerAreaManager.GetInstance().bunny.getHealth() / 100.0f;
		for(int index = 0; index < spriteSwapers.Count; index++)
		{
			spriteSwapers[index].fader.UpdateManualFade(percentage);
		}
	}

	public void ChangeSprites()
	{
		for(int index = 0; index < spriteSwapers.Count; index++)
		{
			spriteSwapers[index].Init();
		}
	}

	public void UpdateSprites(int worldState)
	{
		//for(int index = 0; index < spriteSwapers.Count; index++)
		//{
		//	spriteSwapers[index].StartSwapTo(worldState);
		//}
	}
}
