
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCicle : MonoBehaviour
{
    public GameObject sun;
    public GameObject moon;
    public GameObject sunset;
    public GameObject night;

    public Vector2 centerPos = new Vector2(0, -37f);
    public float radius = 40f;
    public float sunAngle = 80f;
    public float moonAngle = 150f;
    public float sunAngleSpeed = -0.03f;
    public float moonAngleSpeed = -0.04f;

    private bool isSunset = false, isNight = false;

    private Color sunsetColor;
    private float maxAlphaSunset = 0.3f;
    private Color nightColor;
    private float maxAlphaNight = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        //sunAngle = Random.Range(0, 180);
        //moonAngle = Random.Range(0, 180);
        updatePositions();

        sunsetColor = sunset.GetComponent<SpriteRenderer>().color;
        nightColor = night.GetComponent<SpriteRenderer>().color;

        detectChanges();
        if (isSunset)
            sunsetColor.a = maxAlphaSunset;
        if (isNight)
            nightColor.a = maxAlphaNight;

        sunset.GetComponent<SpriteRenderer>().color = sunsetColor;
        night.GetComponent<SpriteRenderer>().color = nightColor;
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

    private void detectChanges()
    {
        isSunset = (sunAngle <= 60 && sunAngle >= 35);
        //    || (sunAngle >= 40 && sunAngle <= 47);

        isNight = (sunAngle <= 50  || sunAngle >= 150);

    }

    // Update is called once per frame
    void Update()
    {
        sunAngle = (sunAngle + sunAngleSpeed) % 180;
        moonAngle = (moonAngle + moonAngleSpeed) % 180;
        if (sunAngle < 0f)
            sunAngle = 180f;
        if (moonAngle < 0f)
            moonAngle = 180f;

        updatePositions();

        detectChanges();

        float absSpeed = Mathf.Abs(sunAngleSpeed);

        if (isSunset)
        {
            if (sunsetColor.a < 0.3f)
            {
                sunsetColor.a = sunsetColor.a + 0.02f* absSpeed;
            }
        }
        else
        {
            if (sunsetColor.a > 0f)
            {
                sunsetColor.a = sunsetColor.a - 0.02f* absSpeed;
            }
        }

        sunset.GetComponent<SpriteRenderer>().color = sunsetColor;

        if (isNight)
        {
            if (nightColor.a < 0.75f)
            {
                nightColor.a = nightColor.a + 0.02f* absSpeed;
            }
        }
        else
        {
            if (nightColor.a > 0f)
            {
                nightColor.a = nightColor.a - 0.02f* absSpeed;
            }
        }

        night.GetComponent<SpriteRenderer>().color = nightColor;

        sun.transform.RotateAround(new Vector2(0, -10), Vector3.back, sunAngle * Mathf.Deg2Rad * Time.deltaTime);
        moon.transform.RotateAround(new Vector2(0, -10), Vector3.back, moonAngle * Mathf.Deg2Rad * Time.deltaTime);
        
    }
}
/*


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
*/
