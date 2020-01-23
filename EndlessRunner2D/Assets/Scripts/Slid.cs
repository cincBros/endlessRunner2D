using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slid : MonoBehaviour
{

    public Slider slider;
    public GameObject handler;
    public Image fill;

    private PU pu;
    private bool activated = false;
    private Color slidColor;

    private void Update()
    {
        if (activated)
        {
            if (slider.value > 0.0f)
            {
                slider.value -= Time.deltaTime;
                if (slider.value < slider.maxValue * 0.25f)
                {
                    slidColor.r = 255;
                    slidColor.b = 0;
                    slidColor.g = 0;
                    fill.color = slidColor;
                }
            }
            else
            {
                Remove();
            }
        }
    }

    public void Activate(PU newPU)
    {
        slidColor.r = 148;
        slidColor.b = 246;
        slidColor.g = 255;
        slidColor.a = 196;
        fill.color = slidColor;

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

    public bool isForPU(PU _pu)
    {
        return isVisible() && _pu.name == pu.name;
    }
}
