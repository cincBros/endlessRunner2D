using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerH : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[3];
    public GameObject[] powerUps = new GameObject[3];
    
    public float respawnTime = 2f;
    public float minRespawnTime = 0.5f;
    public float increment = 0.01f;

    public int powerUpRatio = 50;
    public float speed = 10f;
    public float speedIncr = 0.5f;
    public float maxSpeed = 20f;
    public int points = 25;

    bool isIncremented;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnLoop());
    }

    private void Update()
    {
        if ((score.scoreValue%points == 0) && (!isIncremented) && (speed < maxSpeed))
        {
            speed += speedIncr;
            isIncremented = true;
        }
        else if (score.scoreValue%points != 0) isIncremented = false;

        PUPickUp.speed = bird.speed = runner.speed = cone.speed = speed;

    }

    private void spawnObstacle()
    {
        int i = Random.Range(0, obstacles.Length);
        GameObject a = Instantiate(obstacles[i]) as GameObject;
        Debug.Log("Spawning " + a.name);
    }

    private void spawnPowerUp()
    {
        int i = Random.Range(0, powerUps.Length);
        GameObject a = Instantiate(powerUps[i]) as GameObject;
        Debug.Log("Spawning " + a.name);
    }

    IEnumerator spawnLoop()
    {
        while (true)
        {
            if (respawnTime > minRespawnTime)
            {
                respawnTime = respawnTime - increment;
            }
            yield return new WaitForSeconds(respawnTime);

            int rand = Random.Range(0, 100);
            //int rand = 1; //modoGus
            Debug.Log("RAND: " + rand);
            if (rand <= powerUpRatio)
            {
                spawnPowerUp();
            }
            else
            {
                spawnObstacle();
            }
        }
    }

}
