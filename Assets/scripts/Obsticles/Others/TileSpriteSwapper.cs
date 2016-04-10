using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileSpriteSwapper : MonoBehaviour {

	public List<Sprite> stageSprites;
	bool isSwapping = false;
	public SpriteRenderer renderer;
	public SpriteFader fader;

	[System.NonSerialized]
	public int currentState = 4;

	// Use this for initialization
	void Start () {
		transform.position += new Vector3(0,0,0.01f);
		if(!isSwapping)
			enabled = false;
		TileSpriteManager.GetInstance().AddSwapper(this);
	}
	
	// Update is called once per frame
	void UpdateSprite (float percentage) {
		fader.UpdateManualFade(percentage);
	}

	public void Init()
	{
		fader.SetSprite(stageSprites[0]);
	}

	//public void StartSwapTo(int bunnyState)
	//{
	//	bunnyState = Mathf.Min(stageSprites.Count-1, bunnyState);
	//	if(currentState != bunnyState)
	//	{
	//		fader.FadeFrom(stageSprites[currentState]);
	//		renderer.sprite = stageSprites[bunnyState];
	//		isSwapping = true;
	//		enabled = true;
	//		currentState = bunnyState;
	//	}
	//}
}
