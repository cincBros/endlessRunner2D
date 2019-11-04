using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : spawnable
{
    private void Awake()
    {
        name = "bird";
        yPos = Random.Range(-1, 5);
    }

}
