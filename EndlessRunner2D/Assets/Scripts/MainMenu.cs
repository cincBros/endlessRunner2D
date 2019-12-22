using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene("Game");
	}
	
	public void Settings()
	{
		SceneManager.LoadScene("SettingsMenu");
	}

	public void QuitGame()
	{
		Debug.Log("EXIT");
		Application.Quit();
	}
}
