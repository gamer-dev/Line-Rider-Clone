using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	//variable to keep track that our game is paused or not:
	
	public static bool GameIsPaused = false;
	
	public GameObject pauseMenuUI;
	
	void Start()
	{
		
		pauseMenuUI.SetActive(false);
		
	}
	
	void Update () {

	//Pause the game if the Escape key is pressed:
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(GameIsPaused) //we pressed the Escape key when the game was already paused
			{
				Resume(); //So, Resume the game
			}
			else //we pressed the Esc key, when the game is not paused
			{
				Pause(); //So, actually pause the game
			}
		}
		
	}
	
	void Resume()
	{
		pauseMenuUI.SetActive(false); //hide the pause Menu
		Time.timeScale = 1f; //un-freeze the game
		GameIsPaused = false;
	}
	
	void Pause()
	{
		pauseMenuUI.SetActive(true); //bring up the pause Menu
		Time.timeScale = 0f; //freeze the game
		GameIsPaused = true;
	}
	
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
