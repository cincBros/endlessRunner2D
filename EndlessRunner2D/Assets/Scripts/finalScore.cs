using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{
    Text scoreText;

    public static double result;
    public static double highscore;

    // Start is called before the first frame update
    void Start()
    {
        soundManager.PlaySound("xiuletFinal");
        result = score.scoreValue;
        scoreText = GetComponent<Text>();
		
        if (result > highscore) {
            highscore = result;
        }
        
        scoreText.text = "Score: " + result + "\n" + "Highscore: " + highscore;
    }
}
