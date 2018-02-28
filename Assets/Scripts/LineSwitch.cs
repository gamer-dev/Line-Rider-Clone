using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSwitch : MonoBehaviour {
	

	public void BlackNormal()
	{
		//Debug.Log("Black line!");
		LineCreator.linePrefab = Resources.Load("Line_Normal") as GameObject;
		
	}
	
	public void GreyPass()
	{
		//Debug.Log("Grey line!");
		LineCreator.linePrefab = Resources.Load("Line_Passthrough") as GameObject;
	}
	
	public void RedBoost()
	{
		//Debug.Log("Red line!");
		LineCreator.linePrefab = Resources.Load("Line_Boost") as GameObject;
	}
	
	public void BlueJump()
	{
		//Debug.Log("Blue line!");
		LineCreator.linePrefab = Resources.Load("Line_Bouncy") as GameObject;
	}
}
