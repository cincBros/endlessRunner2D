using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner : MonoBehaviour
{
    public float speed = 2.0f;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        //Assignar limites de la camara
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        this.transform.position = new Vector2(screenBounds.x * -2, -3.3f);
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
}
