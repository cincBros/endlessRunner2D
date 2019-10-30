using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnable : MonoBehaviour
{
    public static float speed = 10.0f;
    new public string name = "spawnable";
    public float yPos;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        //Assignar limites de la camara
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        initialize();
        this.transform.position = new Vector2(screenBounds.x * -2, -yPos);

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

    public virtual void initialize()
    {

    }
}
