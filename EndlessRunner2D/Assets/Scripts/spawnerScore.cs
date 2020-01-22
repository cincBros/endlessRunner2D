using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnerScore : MonoBehaviour
{

    #region Singleton

    public static spawnerScore instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of spawnerScore found!");
            return;
        }

        instance = this;
    }

    #endregion

    public extraPoints ex;

    public void SpawnExtrapoints(int v)
    {
        extraPoints e = Instantiate(ex) as extraPoints;

        e.transform.SetParent(this.transform);


        GameObject t = e.transform.GetChild(0).GetChild(0).gameObject;
        Text _text = t.GetComponent<Text>();
        _text.text += v.ToString();

        /*
        Debug.Log("El text: " + e.getText());
        e.setText(v);
        */
    }

}
