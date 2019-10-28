using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerH : MonoBehaviour
{
    public GameObject runnerPrefab;
    public GameObject conePrefab;
    public GameObject birdPrefab;
    public GameObject powerUpPrefab;
    
    public float respawnTime;
    public float increment;

    public float speed;
    public float speedIncr;
    public float maxSpeed;
    public float points;

    bool isIncremented;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(runnerWave());
    }

    private void Update()
    {
        if ((score.scoreValue%points == 0) && (!isIncremented) && (speed < maxSpeed))
        {
            speed += speedIncr;
            isIncremented = true;
        }
        else if (score.scoreValue%points != 0) isIncremented = false;

        powerUp.speed = bird.speed = runner.speed = cone.speed = speed;
        
    }

    private void spawnObject(int n)
    {
        GameObject obj;

        if (n == 0) obj = runnerPrefab;

        else if (n == 1) obj = conePrefab;

        else if (n == 2) obj = birdPrefab;

        else obj = powerUpPrefab;

        GameObject a = Instantiate(obj) as GameObject;

    }

    IEnumerator runnerWave()
    {
        while (true)
        {
            if (respawnTime > 0.5)
            {
                respawnTime = respawnTime - increment;
            }
            yield return new WaitForSeconds(respawnTime);
            int rand = Random.Range(0, 1000) % 4;
            //int rand = 3; //modoGus

            spawnObject(rand);
        }
    }

}
