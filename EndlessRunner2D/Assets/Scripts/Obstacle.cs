﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    #region Singleton

    public static Obstacle instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Obstacle found!");
            return;
        }

        instance = this;
    }

    #endregion

    public static float speed = 10.0f;
    public float speedAct;
    public new string name = "obstacle";
    public int value = 0;
    public string deathSound;

    protected float xPos = 20f;
    protected float yPos = 3f;

    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void getStarted(float off = 0f)
    {
        //Assignar limites de la camara
        InitializeSprite();
        InitializeTimer();
        transform.position = new Vector2(xPos + off, -yPos);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        speedAct = speed * Time.deltaTime;
        transform.Translate(-speedAct, 0, 0);
        //Detectar cuando esta fuera de camara para borrar
        if (gameObject.transform.position.x < screenBounds.x * 3)
        {
            Destroy(gameObject);
        }
    }

    public virtual void InitializeSprite() { }

    public virtual void InitializeTimer() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		//Debug.Log("Obstacle: entra " + collision.transform.tag);
        if (transform.tag == "enemy" && collision.transform.tag == "player")
        {
			if (playerController.instance.teCasc || playerController.instance.tePildora) {
                score.scoreValue += value;
                score.actualitzarScore();

                extraPoints.instance.startAgain(value);
                soundManager.PlaySound(deathSound);
                Destroy(gameObject);
                
			}
			else {
				//collision.transform.Die();
			}
        }


    }
}
