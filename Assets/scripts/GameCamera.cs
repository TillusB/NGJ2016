﻿using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {


    private static GameCamera _instance;

    public static GameCamera instance
    {
        get 
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("GameCamera");
                _instance = Camera.main.gameObject.AddComponent<GameCamera>();
                _instance.transform.parent = go.transform;
            }
            return _instance; 
        }

    }

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private Transform target;

    void Start () 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update () 
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }  

    public void Shake () 
    {
        iTween.ShakeRotation(gameObject.transform.parent.gameObject,new Vector3(4.0f,1.0f,4.0f)*0.1f,1.2f);
        iTween.ShakePosition(gameObject.transform.parent.gameObject,new Vector3(1.0f,3.0f,1.0f)*0.1f,1.2f);
    }
}
