using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{

    #region Singleton

    public static Sliders instance;

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
    Slider[] sliders = new Slider[8];
    public Transform slidersParent;

    public int nSliders = 0;
    public int maxSliders = 2;

    private void Start()
    {
        sliders = slidersParent.GetComponentsInChildren<Slider>();
        nSliders = 0;
    }

    public bool AddSlider(PU pu)
    {
        if (nSliders >= maxSliders)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        bool stop = false;
        int i = 0;
        while (i < maxSliders && !stop)
        {
            if (sliders[i].fillRect)
            {
                Debug.Log("pot " + pu.name);
                //sliders[i] = new SliderPU(pu);
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
}
