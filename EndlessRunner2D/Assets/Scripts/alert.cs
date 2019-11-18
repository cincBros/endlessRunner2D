using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alert : MonoBehaviour
{

    bool creixent;
    private float x;
    private float y;
    private float z;

    private float xInc;
    private float yInc;

    private double alertTime;

    // Start is called before the first frame update
    void Start()
    {
        creixent = false;
        z = 1;
        x = 0.02f;
        y = 0.02f;

        xInc = 0.0025f;
        yInc = 0.0025f;

        alertTime = 0;
        StartCoroutine(addAlertTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (creixent)
        {
            if (this.transform.localScale.x < 0.06)
            {
                x += xInc;
                y += yInc;
            }
            else
                creixent = false;

        }
        else
        {
            if (this.transform.localScale.x > 0.02)
            {
                x -= xInc;
                y -= yInc;
            }
            else
                creixent = true;
        }

        this.transform.localScale = new Vector3(x, y, z);

        if (alertTime >= 3)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator addAlertTime()
    {

        while (alertTime <= 3)
        {
            alertTime+=0.5f;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
