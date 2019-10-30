using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : spawnable
{
    public override void initialize()
    {
        name = "bird";
        int rand = Random.Range(-1, 5);
        yPos = rand;
        Debug.Log(yPos);
    }

}
