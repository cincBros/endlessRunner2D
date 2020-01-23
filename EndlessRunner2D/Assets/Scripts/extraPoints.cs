using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class extraPoints : MonoBehaviour
{

    #region Singleton

    public static extraPoints instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of extraPoints found!");
            return;
        }

        instance = this;
    }

    #endregion


    // Start is called before the first frame update
    Text _text;

    private float speedFactor = 0f;
    private float speedFactor2 = 0.7f;
    private float speedAct = 0f;
    private Vector3 initialPos;

    void Start()
    {
        _text = gameObject.GetComponent<Text>();
        initialPos = transform.position;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            speedAct += speedFactor * Time.deltaTime;
            speedFactor += speedFactor2;
            transform.Translate(-speedAct, 0.0f, 0.0f);

            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a - 2f * Time.deltaTime);
        }

        if (transform.position.x <= 0)
        {
            stopAgain();
        }
    }

    public void startAgain(int t)
    {
        transform.position = initialPos;
        speedFactor = 0f;
        speedFactor2 = 1f;
        speedAct = 0f;
        setText(t);
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1f);

        gameObject.SetActive(true);
    }

    public void stopAgain()
    {
        gameObject.SetActive(false);
    }

    public void setText(int t)
    {
        _text.text = ("+" + t.ToString());
    }
    public string getText()
    {
        return _text.text;
    }



}
