using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElement : MonoBehaviour
{

    [SerializeField]
    public float speed;
    public float speedAct;

    [SerializeField]
    private Transform neighbour;

    private bool speedChanged = false;

    private void Update()
    {
        if (playerController.instance.teRelan && !speedChanged)
        {
            speedChanged = true;
            speed *= 0.5f;
        }
        if (!playerController.instance.teRelan && speedChanged)
        {
            speedChanged = false;
            speed *= 2.0f;
        }
    }

    public void Move()
    {
        speedAct = spawnerH.instance.speed;
        if(this.tag == "Grades")
        {
            speedAct = speedAct / 3;
        }
        transform.Translate(-speedAct * Time.deltaTime, 0, 0);

    }

    public void SnapToNeighbour()
    {
        transform.position = new Vector2(neighbour.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Reset")
        {
            SnapToNeighbour();
        }
    }


}
