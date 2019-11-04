using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPickUp : spawnable
{
    public float points;

    public PU pu;

    private void Awake()
    {
        name = "powerUp";
        yPos = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Debug.Log("Picking up " + pu.name);
        Destroy(gameObject);
        if (Inventory.instance.Add(pu))
        {
            Destroy(gameObject);
        }
    }
}
