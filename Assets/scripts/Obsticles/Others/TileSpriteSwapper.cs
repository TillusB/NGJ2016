using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileSpriteSwapper : MonoBehaviour {

	public List<Sprite> stageSprites;
	bool isSwapping = false;
	public SpriteRenderer renderer;
	public SpriteFader fader;

	public int currentState = 5;

	// Use this for initialization
	void Start () {
		if(!isSwapping)
			enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSwapTo(int bunnyState)
	{
		bunnyState = Mathf.Max(1, bunnyState);
		if(currentState != bunnyState)
		{
			fader.FadeFrom(stageSprites[currentState]);
			renderer.sprite = stageSprites[bunnyState];
			isSwapping = true;
			enabled = true;
		}
	}
}
