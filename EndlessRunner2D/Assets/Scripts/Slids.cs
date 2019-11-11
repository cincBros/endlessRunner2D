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

    public PU pu;
    Slid[] sliders = new Slid[3];

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

    public bool AddSlider(PU puAdd)
    {
        pu = puAdd;

        if (nSliders >= maxSliders)
        {
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

    public void Remove()
    {
        nSliders--;
    }

    private void Update()
    {
    }
}
