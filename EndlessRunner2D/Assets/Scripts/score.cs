using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    Text scoreText;
    public static bool viu;
    public static double scoreValue;
    public float respawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        viu = true;
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
        while (viu)
        {
            scoreValue++;
            yield return new WaitForSeconds(respawnTime);
        }
    }
}
