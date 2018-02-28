using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will change the player's rigidbody type to dynamic, so the player can be influenced by the lines' physics

public class Player : MonoBehaviour {
	
	//First, we'll need to refer the player's rigidbody component
	
	public Rigidbody2D rb;
	
	void Update()
	{
		if(Input.GetButtonDown("Play")) 
		{
			rb.bodyType = RigidbodyType2D.Dynamic; // change the rigidbody type
		}
		
	}
	
}
