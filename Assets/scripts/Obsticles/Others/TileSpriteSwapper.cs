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

	public bool createChild = false;

	// Use this for initialization
	void Start () {
		transform.position += new Vector3(0,0,0.01f);

		if(createChild)
		{
			GameObject obj = new GameObject("ChildFade");
			obj.transform.parent = transform;
			fader = obj.AddComponent<SpriteFader>();
			fader.renderer = obj.AddComponent<SpriteRenderer>();
			fader.renderer.material = Instantiate(Resources.Load("SpriteSwapperMaterial")) as Material;
			obj.transform.localPosition = new Vector3(0,0,-0.01f);
			obj.transform.localScale = Vector3.one;
		}
		if(renderer == null)
			renderer = GetComponent<SpriteRenderer>();
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
