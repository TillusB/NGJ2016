using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxBGController : MonoBehaviour {

	[SerializeField] List<ParallaxLayer> parallaxLayers;

	[System.Serializable]
	public class ParallaxLayer{
		public Transform layerTrans;
		public float moveXWithCamFrac;
		public float moveYWithCamFrac;

		public float offsetX;
		public float offsetY;
	}
		
	Camera mainCam;

	void Awake(){
		mainCam = Camera.main;
//		UpdatePos();

		foreach (ParallaxLayer pLayer in parallaxLayers) {
			pLayer.offsetX = pLayer.layerTrans.transform.position.x;
			pLayer.offsetY = pLayer.layerTrans.transform.position.y;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		UpdatePos();
	}

	void UpdatePos(){
		foreach (ParallaxLayer pLayer in parallaxLayers) {
			Vector3 newPos = pLayer.layerTrans.transform.position;
			newPos.x = mainCam.transform.position.x * pLayer.moveXWithCamFrac + pLayer.offsetX;
			newPos.y = mainCam.transform.position.y * pLayer.moveYWithCamFrac + pLayer.offsetY;
			pLayer.layerTrans.position = newPos;

		}


			
	}
}
