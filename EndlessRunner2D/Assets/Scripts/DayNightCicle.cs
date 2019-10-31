/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCicle : MonoBehaviour
{
    public GameObject sun;
    public GameObject moon;
    public GameObject sunset;
    public GameObject night;

    public Vector2 centerPos = new Vector2(0, -11f);
    public float radius = 4f;
    public float sunAngle = 90f;
    public float moonAngle = 270f;
    public float sunAngleSpeed = 0.2f;
    public float moonAngleSpeed = 0.3f;

    private Color sunsetColor;
    private Color nightColor;

    // Start is called before the first frame update
    void Start()
    {
        updatePositions();

        sunsetColor = sunset.GetComponent<SpriteRenderer>().color;
        nightColor = night.GetComponent<SpriteRenderer>().color;
    }

    private void updatePositions()
    {
        float a = sunAngle * Mathf.Deg2Rad;
        float posX = centerPos.x + Mathf.Cos(a) * radius;
        float posY = centerPos.y + Mathf.Sin(a) * radius;
        sun.transform.position = new Vector2(posX, posY);

        a = moonAngle * Mathf.Deg2Rad;
        posX = centerPos.x + Mathf.Cos(a) * radius;
        posY = centerPos.y + Mathf.Sin(a) * radius;
        moon.transform.position = new Vector2(posX, posY);
    }

    // Update is called once per frame
    void Update()
    {
        sunAngle += sunAngleSpeed;
        moonAngle += moonAngleSpeed;
        updatePositions();

        //sunsetColor.a += 0.001f;

        //sunset.GetComponent<SpriteRenderer>().color = sunsetColor;

        /*
        detectChanges();

        if (sunset)
        {
            if (sunsetT.a < 0.3f)
            {
                sunsetT.a = sunsetT.a + 0.0003f;
            }
        }
        else
        {
            if (sunsetT.a > 0)
            {
                sunsetT.a = sunsetT.a - 0.001f;
            }
        }

        sunsetP.GetComponent<SpriteRenderer>().color = sunsetT;

        if (night)
        {
            if (nightT.a < 0.8f)
            {
                nightT.a = nightT.a + 0.0014f;
            }
        }
        else
        {
            if (nightT.a > 0)
            {
                nightT.a = nightT.a - 0.0006f;
            }
        }

        nightP.GetComponent<SpriteRenderer>().color = nightT;

        sun.transform.RotateAround(new Vector2(0, -10), Vector3.back, angleSpeed * Time.deltaTime);
        moon.transform.RotateAround(new Vector2(0, -10), Vector3.back, angleSpeed * Time.deltaTime);
        
    }
}
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCicle : MonoBehaviour
{
    public GameObject sunsetPrefab;
    public GameObject darkPrefab;
    public GameObject moonPrefab;
    public GameObject sunPrefab;

    private GameObject sun;
    private GameObject moon;
    private GameObject sunsetP;
    private GameObject nightP;

    public float angleSpeed = 1.9f;

    private bool sunset = false, night = false;

    private Color sunsetT;
    private Color nightT;

    private void detectChanges()
    {

        if ((sun.transform.position.x < -8 && sun.transform.position.y > -10.5f) || (sun.transform.position.x > 6 && sun.transform.position.y > -10.5f))
        {
            sunset = true;
        }
        else
        {
            sunset = false;
        }
        
        if (moon.transform.position.y > -10.5f)
        {
            night = true;
        }
        else
        {
            night = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        sun = Instantiate(sunPrefab) as GameObject;
        moon = Instantiate(moonPrefab) as GameObject;
        sunsetP = Instantiate(sunsetPrefab) as GameObject;
        nightP = Instantiate(darkPrefab) as GameObject;

        moon.transform.position = new Vector2(0, -24.0f);
        sun.transform.position = new Vector2(0, 4.50f);

        sunsetT = sunsetP.GetComponent<SpriteRenderer>().color;
        nightT = nightP.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        detectChanges();

        if (sunset)
        {
            if (sunsetT.a < 0.3f)
            {
                sunsetT.a = sunsetT.a + 0.0003f;
            }
        }
        else
        {
            if (sunsetT.a > 0)
            {
                sunsetT.a = sunsetT.a - 0.001f;
            }
        }

        sunsetP.GetComponent<SpriteRenderer>().color = sunsetT;

        if (night)
        {
            if (nightT.a < 0.8f)
            {
                nightT.a = nightT.a + 0.0014f;
            }
        }
        else
        {
            if (nightT.a > 0)
            {
                nightT.a = nightT.a - 0.0006f;
            }
        }

        nightP.GetComponent<SpriteRenderer>().color = nightT;

        sun.transform.RotateAround(new Vector2(0, -10), Vector3.back, angleSpeed * Time.deltaTime);
        moon.transform.RotateAround(new Vector2(0, -10), Vector3.back, angleSpeed * Time.deltaTime);
    }
}

