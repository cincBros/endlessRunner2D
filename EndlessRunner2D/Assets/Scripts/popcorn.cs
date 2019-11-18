using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcorn : MonoBehaviour
{
    public float speed = 10.0f;
    public float z;
    public float zIncrement = 5.0f;
    public SpriteRenderer spr;


    // private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        z = 0;
        spr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        if (this.transform.position.y < -6.5f) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "player" && (playerController.instance.teCasc || playerController.instance.tePildora))
        {
            Destroy(gameObject);
        }
    }

}
