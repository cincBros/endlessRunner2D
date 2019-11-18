using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPickUp : MonoBehaviour
{
    public static float speed = 10.0f;
    public new string name = "powerup";

    public PU pu;
    public GameObject puSprite;
    public GameObject star;

    protected float xPos = 20f;
    protected float yPos = 3f;

    private Vector2 screenBounds;
	private float angleRot = 0f;			// Angle for the rotation movement
	private float angleRotIncrease = 5f;	// Increase of the angle of the rotation movement

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void getStarted(float off = 0f)
    {
        transform.position = new Vector2(xPos + off, -yPos);
		angleRot = Random.Range(0, 359);
		
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        //Detectar cuando esta fuera de camara para borrar
        if (gameObject.transform.position.x < screenBounds.x * 3)
        {
            Destroy(gameObject);
        }
		
		// Rotate PU
		angleRot = angleRot%360 + angleRotIncrease;
		puSprite.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Cos(angleRot * Mathf.Deg2Rad) * 15f);
		
		// Rotate star
        star.transform.Rotate(new Vector3(star.transform.rotation.x, star.transform.rotation.y, star.transform.rotation.z + 1f));
		
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            Pickup();
        }
    }

    void Pickup()
    {
        if (Inventory.instance.Add(pu))
        {
            Remove();
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
