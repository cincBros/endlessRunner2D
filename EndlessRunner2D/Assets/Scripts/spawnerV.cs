using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerV : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[2];
    public GameObject alert;
    public int points = 25;
    int rand;

    bool spawned;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (score.scoreValue % points == 0 && !spawned)
        {
            rand = (Random.Range(-10, 7));
            int idx = Random.Range(0, obstacles.Length);
            GameObject enemy = Instantiate(obstacles[idx]) as GameObject;
            GameObject a = Instantiate(alert) as GameObject;
            enemy.transform.position = new Vector3(rand, 30, 0);
            a.transform.position = new Vector3(rand, 5, 0);
            soundManager.PlaySound("alarm");
            spawned = true;
        }
        else if (score.scoreValue % points != 0)
        {
            spawned = false;
        }
    }
}
