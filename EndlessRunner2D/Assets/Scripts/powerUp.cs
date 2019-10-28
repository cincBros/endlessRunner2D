using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public static float speed;
    public float points;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        //Assignar limites de la camara
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        int rand = (Random.Range(1, 100) % 6) + 1;
        rand -= 5;
        this.transform.position = new Vector2(screenBounds.x * -2, rand);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        //Detectar cuando esta fuera de camara para borrar
        if (this.gameObject.transform.position.x < screenBounds.x * 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            Destroy(gameObject);
        }
    }

    public void setSpeed(float s)
    {
        speed = s;
    }
}
