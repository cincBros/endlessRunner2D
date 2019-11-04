using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnable : MonoBehaviour
{
    public static float speed = 10.0f;
    new public string name = "spawnable";

    protected float xPos = 20f;
    protected float yPos = 3f;

    private Vector2 screenBounds;

    // Start is called before the first frame update


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void getStarted(float off = 0f)
    {
        //Assignar limites de la camara
        initializeSprite();
        transform.position = new Vector2(xPos + off, -yPos);
    }

    public void setOffsetX(float off)
    {
        Debug.Log("set: " + xPos);
        transform.position = transform.position + new Vector3(off, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        //Detectar cuando esta fuera de camara para borrar
        if (gameObject.transform.position.x < screenBounds.x * 3)
        {
            Destroy(gameObject);
        }
    }

    public virtual void initializeSprite()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.tag == "enemy" && collision.transform.tag == "player" && (playerController.instance.teCasc || playerController.instance.tePildora))
        {
            Destroy(gameObject);
        }


    }
}
