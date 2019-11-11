using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPickUp : spawnable
{
    public PU pu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            Pickup();
        }
    }

    void Pickup()
    {
        if (Inventory.instance.Add(pu))
        {
            Remove();
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
