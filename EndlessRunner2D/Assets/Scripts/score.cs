using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    Text scoreText;
    
    public static double scoreValue;
    public float respawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        scoreText = GetComponent<Text>();
        StartCoroutine(addScore());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    IEnumerator addScore()
    {
        while (playerController.instance.viu)
        {
            scoreValue++;
            yield return new WaitForSeconds(respawnTime);
        }
    }
}
