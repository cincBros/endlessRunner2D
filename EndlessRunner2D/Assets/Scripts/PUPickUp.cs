using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPickUp : spawnable
{
    private float timeLeft;
    private bool activated = false;

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
        if (Inventory.instance.Add(this))
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void Use()
    {
        if (name == "casc")
        {
            playerController.instance.activarCasc(true);
        }
        else if (name == "molles")
        {
            playerController.instance.activarMolles(true);
            Slids.instance.AddSlider(this);
        }
        else if (name == "pildora")
        {
            playerController.instance.activarPildora(true);
            Slids.instance.AddSlider(this);
        }

        activated = true;
        timeLeft = pu.time;
    }

    protected override void Update()
    {
        if (!activated)
        {
            base.Update();
        }
        else
        {
            if (activated && timeLeft > 0.0f)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("STOP");
                Remove();
            }
        }
    }

    public void Remove()
    {
        if (name == "casc")
        {
            playerController.instance.activarCasc(false);
        }
        else if (name == "molles")
        {
            playerController.instance.activarMolles(false);
        }
        else if (name == "pildora")
        {
            playerController.instance.activarPildora(false);
        }

        Slids.instance.Remove(this);
        
        Destroy(gameObject);
    }
}
