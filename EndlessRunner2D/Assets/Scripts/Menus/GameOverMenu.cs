using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Text scoreText;

    public static double result;
    public static double highscore;
    
	void Start()
    {
        soundManager.PlaySound("xiuletFinal");
        result = score.scoreValue;
		highscore = Highscores.Highest();
        
        scoreText.text = "Score: " + result;
		if (result > highscore)
			scoreText.text += "  (Record)";
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
