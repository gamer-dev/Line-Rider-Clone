using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour {
	
	//In our game, the line is controlled by its two main components:
	//Line Renderer : to show the line on the screen
	//Edge Collider : to set the physics on the line, more suitable than other colliders

	//We should reference these two components that make our line and control them suitably
	
	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	
	//We need to store the points (co-ordinated) for the line:
	//Use List as insertion and deletion can be done easily, flexible
	//Array is static, list is dynamic
	//And in our game, we need to be able to add or possibly delete line segments
	
	List<Vector2> points;
	
	//To update the points on the line and set up the line 
	public void UpdateLine(Vector2 mousePos) // call it by giving it a mouse position, a vector2 of X,Y co-ordinates 
	{
		if(points == null) //if our list is empty, then instantiate it:
		{
			points = new List<Vector2>();
			SetPoint(mousePos); //add point to the list
			return;
		}
		
		//Now, if our list is not empty then:
		
		//Check if the mouse has been moved by enough distance, we want a drag, not just a click
		//and if it has, we have to insert new point at the mouse position(s)
		
		//So, check the distance between the last 2 points (new and old):
		
		if(Vector2.Distance(points.Last(), mousePos) > 0.1f) //so if the distance between the old point (last point -- in the list) and the new point is more than .1f, then insert it into the list and update line renderer and edge renderer
		{
			SetPoint(mousePos);
			return;
		}
		else
		{
			//ignore the point, as its not valid in our course
		}
		
	}
	
	void SetPoint(Vector2 point) //point = mouse position to refer a point on the screen
	{
		points.Add(point); //Add the given mouse position to the list of points to be rendered
		
		lineRenderer.numPositions = points.Count; // set the number of points on the line renderer equal to the number of points in our points list!
		
		//we set the number/size of the points to render, but now we'll have to add the points into the lineRenderer component
		
		lineRenderer.SetPosition(points.Count - 1, point); //add the latest point (i.e the last of the list), subtract by 1 so as to match the index of the list, index starts from 0
		
		if(points.Count > 1) //edge collider will throw error if there is only 1 point, we need atleast 2 points to create a line:
		{
		edgeCol.points = points.ToArray(); //edgeCol.points is an array, so convert points list by ToArray() methods
		}
		
	}
	
	
}
