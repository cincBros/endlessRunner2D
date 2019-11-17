using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerV : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[2];

    public int points = 25;

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
            int idx = Random.Range(0, obstacles.Length);
            GameObject enemy = Instantiate(obstacles[idx]) as GameObject;
            spawned = true;
        }
        else if (score.scoreValue % points != 0)
        {
            spawned = false;
        }
    }
}
