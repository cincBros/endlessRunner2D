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

    public float speed;
    public float speedIncr;
    public float maxSpeed;
    public float points;

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

    private void spawnObject(int n)
    {

        GameObject a = Instantiate(obstacles[n]) as GameObject;
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
            int rand = Random.Range(0, 3);
            //int rand = 3; //modoGus

            spawnObject(rand);
        }
    }

}
