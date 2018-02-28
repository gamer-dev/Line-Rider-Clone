using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//Reference to what we want to follow:
	
	public Transform player; //use Transform, for getting the position of the player gameobject
	
	public Rigidbody2D playerRb;
	
	//How quickly will the camera snap to the target?
	
	public float smoothSpeed = 0.125f;
	
	//Add offset for camera position:
	//Vector3 to store X,Y,Z co-ordinates
	public Vector3 offset;
	private Vector3 velocity = Vector3.zero;
	//Method to snap the camera to the target:
	//Don't use start(), as it occurs only once
	//Don't use Update(), as our target also updates in Update() and both our camera and player will be competing with each other
	
	//use LateUpdate() as it occurs only after everything in Update() has happened:
	
	
	void LateUpdate()
	{
		
		if(playerRb.bodyType != RigidbodyType2D.Dynamic)
		{
			
			
			if(Input.GetAxisRaw("Horizontal")>0f)
			{
				Debug.Log("Move Right!");
				transform.position  = new Vector3(transform.position.x+2, transform.position.y, transform.position.z );
			}
			
			else if(Input.GetAxisRaw("Horizontal")<0f)
			{
				Debug.Log("Move Left!");
				transform.position  = new Vector3(transform.position.x-2, transform.position.y, transform.position.z );
			}
			
			else if(Input.GetAxisRaw("Vertical")>0f)
			{
				Debug.Log("Move Up!");
				transform.position  = new Vector3(transform.position.x, transform.position.y+2, transform.position.z );
			}
			
			else if(Input.GetAxisRaw("Vertical")<0f)
			{
				Debug.Log("Move Down!");
				transform.position  = new Vector3(transform.position.x, transform.position.y-2, transform.position.z );
			}
			
		}
		
		else if (playerRb.bodyType == RigidbodyType2D.Dynamic)
		{
		//Set the current position of the camera to the position of the target (player):
		
		Vector3 desiredPosition = player.position + offset;		
		
		//Use SmoothDamp to move the camera smoothly
		Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed*Time.deltaTime);
		transform.position = smoothedPosition;
		
		//the camera will always make the player as its center
		transform.LookAt(player);
		
		}
	}
	
	
	
	
}
