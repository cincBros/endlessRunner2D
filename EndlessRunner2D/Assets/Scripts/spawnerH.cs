using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerH : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[3];
    public GameObject[] powerUps = new GameObject[3];
    
    public float respawnTime;
    public float minRespawnTime;
    public float increment;

    public float speed = 2f;
    public float speedIncr = 0.01f;
    public float maxSpeed = 0.5f;
    public int points = 25;
    public int ratioPowerUp = 25;

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

    private void spawnPowerUp()
    {
        int rand = Random.Range(0, powerUps.Length);
        GameObject a = Instantiate(powerUps[rand]) as GameObject;

        Debug.Log("Spawning " + a.name);
    }

    private void spawnObstacle()
    {
        int rand = Random.Range(0, obstacles.Length);
        GameObject a = Instantiate(obstacles[rand]) as GameObject;
       
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
            //int rand = 3; //modoGus

            if (rand <= ratioPowerUp)
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
