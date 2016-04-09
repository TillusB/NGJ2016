using UnityEngine;
using System.Collections;

public class SpriteFader : MonoBehaviour {

	public SpriteRenderer renderer;
	public const float maxDuration = 0.3f;
	float duration = 0;
	public bool isFading = false;

	void Start()
	{
		if(!isFading)
		{
			enabled = false;
		}		
	}

	// Update is called once per frame
	void Update () {
		if(isFading)
		{
			if(duration < maxDuration)
			{
				renderer.material.color = new Color(1, 1, 1, 1 - duration / maxDuration);
			}
			else
			{
				gameObject.SetActive(false);
				isFading = false;
				enabled = false;
			}
		}
	}

	public void FadeFrom(Sprite sprite)
	{
		gameObject.SetActive(true);
		enabled = true;
		isFading = true;
		renderer.sprite = sprite;
		renderer.material.color = new Color(1, 1, 1, 1);
	}
}
