using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Text scoreText;
    public GameObject recordText;

    public static double result;
    public static double highscore;
    
	void Start()
    {
        soundManager.PlaySound("xiuletFinal");
        result = score.scoreValue;
		highscore = Highscores.Highest();
        
        scoreText.text = "Score: " + result;
		if (result > highscore) recordText.SetActive(true);
		else recordText.SetActive(false);
		scoreText.text += "\nHighscore: " + highscore;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
