using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slid : MonoBehaviour
{

    public Slider slider;
    public GameObject handler;

    private PU pu;
    private bool activated = false;

    private void Update()
    {
        if (activated)
        {
            if (slider.value > 0.0f)
            {
                slider.value -= Time.deltaTime;
            }
            else
            {
                Remove();
            }
        }
    }

    public void Activate(PU newPU)
    {
        slider.gameObject.SetActive(true);
        pu = newPU;

        activated = true;
        handler.GetComponent<Image>().sprite = pu.icon;
        slider.maxValue = pu.time;
        slider.value = pu.time;
        slider.minValue = 0.0f;
        
    }

    public void Remove()
    {
        if (activated)
        {
			playerController.instance.DeactivatePU(pu);
            activated = false;
        }
        slider.gameObject.SetActive(false);
        Slids.instance.Remove();
    }

    public bool isVisible()
    {
        return slider.gameObject.activeSelf;
    }
}
