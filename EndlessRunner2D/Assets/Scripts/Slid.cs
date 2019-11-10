using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slid : MonoBehaviour
{

    public Slider slider;
    public GameObject handler;

    public void Activate(PUPickUp pu)
    {
        slider.gameObject.SetActive(true);
        handler.GetComponent<Image>().sprite = pu.pu.icon;
    }
    public void Remove()
    {
        slider.gameObject.SetActive(false);
    }

    public bool isVisible()
    {
        return slider.gameObject.activeSelf;
    }
}
