using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slids : MonoBehaviour
{

    #region Singleton

    public static Slids instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Sliders found!");
            return;
        }

        instance = this;
    }

    #endregion

    public PUPickUp pu;
    Slid[] sliders = new Slid[8];

    private int nSliders = 0;
    private int maxSliders = 3;

    private void Start()
    {
        sliders = GetComponentsInChildren<Slid>();
        for (int i = 0; i < maxSliders; i++)
        {
            sliders[i].Remove();
        }
        maxSliders = sliders.Length;
        nSliders = 0;
    }

    public bool AddSlider(PUPickUp puAdd)
    {
        pu = puAdd;

        if (nSliders >= maxSliders)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        bool stop = false;
        int i = 0;
        while (i < maxSliders && !stop)
        {
            if (!sliders[i].isVisible())
            {
                sliders[i].Activate(pu);
                nSliders++;
                stop = true;
            }
            else
            {
                i++;
            }
        }

        return true;
    }

    public void Remove(PUPickUp puRemove)
    {
        int i = 1;
        bool stop = false;

        while (!stop && i < sliders.Length)
        {
            if (puRemove == pu)
            {
                sliders[i].Remove();
                stop = true;
            }
            else
            {
                i++;
            }
        }
    }

    private void Update()
    {
        /*
        for (int i = 0; i < maxSliders; i++)
        {
            if (sliders[i].isVisible())
                sliders[i].transform.position += new Vector3(1, 0, 0);
        }
        */
    }
}
