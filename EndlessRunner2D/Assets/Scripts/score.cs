using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static Text scoreText;
    
    public static int scoreValue;
    public float respawnTime = 0.5f;

    public bool tutorial;
    private static bool counting;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = "";
        counting = !tutorial;
        StartCoroutine(addScore());
    }

    IEnumerator addScore()
    {
        while (playerController.instance.viu)
        {
            if (counting)
            {
                scoreText.text = "Score: " + scoreValue;
                scoreValue++;
            }
            yield return new WaitForSeconds(respawnTime);
        }
    }

    public static void actualitzarScore()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    public static void startCounting()
    {
        counting = true;
    }
}
