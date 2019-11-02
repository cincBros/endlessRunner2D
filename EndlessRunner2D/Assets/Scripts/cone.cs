using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cone : spawnable
{
    public Sprite[] coneSprites = new Sprite[3];
    private SpriteRenderer spr;

    public override void initialize()
    {
        name = "cone";
        yPos = 4.2f;
        spr = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, coneSprites.Length);
        spr.sprite = coneSprites[rand];
    }
}
