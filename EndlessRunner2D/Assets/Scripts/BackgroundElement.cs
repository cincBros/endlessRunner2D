using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundElement : MonoBehaviour
{

    [SerializeField]
    public float speed;

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
        transform.Translate(Vector2.left * speed * Time.smoothDeltaTime);
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
