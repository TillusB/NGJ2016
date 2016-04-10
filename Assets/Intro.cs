using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
    public GameObject Player;
    Bunny bunny;
    public Camera introCam;
    public GameObject startPoint;
    private BloodSpurter blood;
    private Vector3 originalCamPos;
    private float originalCamSize;
	// Use this for initialization
	void Start () {
        originalCamPos = introCam.transform.position;
        originalCamSize = introCam.orthographicSize;
	    if(Player != null)
        {
            bunny = Player.GetComponent<Bunny>();
        }
        if (bunny != null)
        {
            blood = bunny.gameObject.GetComponentInChildren<BloodSpurter>();

        }
        StartCoroutine(PlayIntro());
	}
	
	// Update is called once per frame
	void Update () {
	}

    private IEnumerator PlayIntro()
    {
        yield return new WaitForEndOfFrame();
        bunny.rb.velocity = new Vector2(2, 0);
        while ((Player.transform.position.x <= startPoint.transform.position.x - 3) && !(Player.transform.position.x >= startPoint.transform.position.x + 3))
        {
            yield return new WaitForEndOfFrame();
        }
        bunny.rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1);
        while(introCam.orthographicSize > 3)
        {
            introCam.orthographicSize = Mathf.Lerp(introCam.orthographicSize, 2, Time.deltaTime);
            introCam.transform.position = Vector3.Lerp(introCam.transform.position, new Vector3(bunny.transform.position.x, bunny.transform.position.y, introCam.transform.position.z), Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2f);
        // TODO: Play gun sound
        Debug.Log("BANG!");
        while (introCam.orthographicSize < originalCamSize -1)
        {
            introCam.orthographicSize = Mathf.Lerp(introCam.orthographicSize, originalCamSize, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Application.LoadLevel("PlayScene");
        yield return null;
    }
}
