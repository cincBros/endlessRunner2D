using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle : MonoBehaviour
{
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
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
