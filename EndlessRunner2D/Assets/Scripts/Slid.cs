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
            if (pu.name == "casc")
            {
                playerController.instance.activarCasc(false);
            }
            else if (pu.name == "molles")
            {
                playerController.instance.activarMolles(false);
            }
            else if (pu.name == "pildora")
            {
                playerController.instance.activarPildora(false);
            }
            else if (pu.name == "relantitzador")
            {
                playerController.instance.activarRelan(false);
                spawnerH.instance.speed *= 2.0f;
                spawnerH.instance.respawnTime *= 0.5f;
                
            }
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
