using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerH : MonoBehaviour
{
    #region Singleton

    public static spawnerH instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of SpawnerH found!");
            return;
        }

        instance = this;
    }

    #endregion

    public Obstacle[] obstacles = new Obstacle[3];
    public PUPickUp[] powerUps = new PUPickUp[3];
    
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
        PUPickUp a = Instantiate(powerUps[rand]) as PUPickUp;
        a.getStarted(0f);
    }

    private void spawnObstacle()
    {
        int idx = Random.Range(0, obstacles.Length);
        //int idx = 1; //conos
        Obstacle a = Instantiate(obstacles[idx]) as Obstacle;
        a.getStarted(0f);

        if (a.name == "cone")
        {
            int rand = Random.Range(0, 3);
            for (int i=0; i<rand; i++)
            {
                a = Instantiate(obstacles[idx]) as Obstacle;
                a.getStarted(1f*i + 1f);
            }
        }

    }

    IEnumerator spawnLoop()
    {
        while (playerController.instance.viu)
        {
            if (respawnTime > minRespawnTime)
            {
                respawnTime = respawnTime - increment;
            }
            yield return new WaitForSeconds(respawnTime);

            int rand = Random.Range(0, 100);
            //int rand = 0; //modoGus

            if (0 <= ratioPowerUp)
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
