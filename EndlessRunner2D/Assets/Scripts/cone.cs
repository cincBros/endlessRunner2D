using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cone : spawnable
{
    public Sprite[] coneSprites = new Sprite[3];
    private SpriteRenderer spr;

    private void Awake()
    {
        name = "cone";
        yPos = 4.7f;
    }

    public override void InitializeSprite()
    {
        spr = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, coneSprites.Length);
        spr.sprite = coneSprites[rand];
    }
}
