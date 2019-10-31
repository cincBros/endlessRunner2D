using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerV : MonoBehaviour
{
    public GameObject ballPrefab;

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
            GameObject a = Instantiate(ballPrefab) as GameObject;
            spawned = true;
        }
        else if (score.scoreValue % points != 0)
        {
            spawned = false;
        }
    }
}
