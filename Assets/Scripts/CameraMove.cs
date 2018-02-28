using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	
	public Rigidbody2D playerRb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(playerRb.bodyType == RigidbodyType2D.Dynamic)
		{
			Debug.Log("Player is moving!");
		}
		
		
	}
}
