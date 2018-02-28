using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controller for the line prefab
//This will take the actual input from the user and render it on the screen 

public class LineCreator : MonoBehaviour {
	
	//Reference to the line prefab
	public static GameObject linePrefab;
	
	void Awake()
	{
		linePrefab = Resources.Load("Line_Normal") as GameObject; //set the normal line as the default prefab, before it is changed by the LineSwitch script
	}
	
	Line activeLine;

	//The 1st task is to take input from the player
	//Which should be done in every frame. So :
	
	void Update()
	{

		//Getting the input, in our case, a mouse click of the left button:
		
		if(Input.GetMouseButtonDown(0)) //when the user click and holds the mouse button:
		{
			//Instantiate a new line:
			GameObject lineGO = Instantiate(linePrefab); //store the instantiation in a variable, to use the variable to get the line script within the object
			
			//store the line in it:
			activeLine = lineGO.GetComponent<Line>();
			
			/* --- Input part done, now have to display the line on the screen, using the functions on the line script ---*/
		}
		
		if(Input.GetMouseButtonUp(0)) //when the user releases the mouse button, the line should not be drawn, so set the points list to be null
		{
			activeLine = null;
		}
		
		
		if(activeLine != null) //only attempt to render the line, if there is something in it, i.e its not empty!
		{
		//To show on the screen, we have to specify Where and how?
		//Where = the position the mouse was clicked in:
		//And since its a 2D game, we'll need only X and Y co - ordinates
		//So, store it in a Vector2 as:
		
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //converting from pixel co-ordinates to world co-ordinates
		activeLine.UpdateLine(mousePos); //Use the UpdateLine method to render the lines on the screen by manipulating the line renderer and edge collider component
		}
	}

}
