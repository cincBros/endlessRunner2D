using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : Obstacle
{
    private void Awake()
    {
        name = "bird";
        yPos = Random.Range(-1, 5);
        value = 5;
        deathSound = "birdHit";
    }
}
