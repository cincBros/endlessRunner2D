using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    Text scoreText;
    
    public static int scoreValue;
    public float respawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        scoreText = GetComponent<Text>();
        StartCoroutine(addScore());
        scoreText.text = "Score: " + scoreValue;
    }

    IEnumerator addScore()
    {
        while (playerController.instance.viu)
        {
            scoreValue++;
			scoreText.text = "Score: " + scoreValue;
            yield return new WaitForSeconds(respawnTime);
        }
    }
}
