using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcorn : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject alert;
    int rand;

    // private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        //Assignar limites de la camara
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        rand = (Random.Range(-11, 11));
        this.transform.position = new Vector2(rand, 20);
        
        alert.transform.position = new Vector2(rand, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        if (this.transform.position.y < -6.5f) Destroy(gameObject);
        if (this.transform.position.y < 10f) Destroy(alert);
    }

}
