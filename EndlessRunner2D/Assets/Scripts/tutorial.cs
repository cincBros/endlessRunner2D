using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    int steps, timer;
    bool stepdone;
    public GameObject coach;
    GameObject coachText;
    Text _text;
    public Image moure, saltar, tackle, pu, play;
    
    // Start is called before the first frame update
    void Start()
    {
        steps = 0;
        timer = 0;
        stepdone = false;
        moure.enabled = saltar.enabled = tackle.enabled = pu.enabled = play.enabled = false;
        StartCoroutine("addTimer");
        spawnerV.instance.setTutorial();
        coachText = coach.transform.GetChild(0).GetChild(0).gameObject;
        _text = coachText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(steps){
            case 0: showMovement(); break;
            case 1: showJumping(); break;
            case 2: showFallFaster(); break;
            case 3: showTackle(); break;
            case 4: showPowerUpsInfo(); break;
            case 5: showPowerUps(); break;
            case 6: showObjectsV(); break;
            case 7: startPlaying(); break;
        }
    }

    void showMovement()
    {
        _text.text = "Use the left joystick, left-right arrow keys or A-D keys to move";
        if (Input.GetButton("Left") || Input.GetButton("Right") || Input.GetAxis("Run") > 0) stepdone = true;
        moure.enabled = true;

        if (stepdone && timer >= 5)
        {
            timer = 0;
            moure.enabled = false;
            stepdone = false;
            steps++;
        }
    }
    void showJumping()
    {
        saltar.enabled = true;
        _text.text = "Press the X button, up arrow key or W key to jump\n[you can jump twice in a row]";
        if (Input.GetButton("Jump")) stepdone = true;

        if (stepdone && timer >= 5)
        {
            saltar.enabled = false;
            timer = 0;
            stepdone = false;
            steps++;
        }
    }

    void showFallFaster()
    {
        tackle.enabled = true;
        _text.text = "Once you have jumped, you can fall faster pressing the O button, down arrow key or S key";
        if (timer >= 5)
        {
            tackle.enabled = false;
            timer = 0;
            steps++;
        }
    }

    void showTackle()
    {
        tackle.enabled = true;
        _text.text = "Press the O button, down arrow key or S key to tackle";
        if (Input.GetButton("Tackle")) stepdone = true;

        if (stepdone && timer >= 5)
        {
            timer = 0;
            tackle.enabled = false;
            stepdone = false;
            steps++;
        }
    }


    void showPowerUpsInfo()
    {
        if (!stepdone)
        {
            Debug.Log("spawned");
            spawnerH.instance.setMaxRatio();
            spawnerH.instance.startSpawning();
            stepdone = true;
        }
        
        //Inventory.instance.ActivarInventori();
        _text.text = "There are some Power Ups you can pick up, which are stored in your inventory";
        if (timer >= 5)
        {
            timer = 0;
            stepdone = false;
            steps++;
        }
    }

    void showPowerUps()
    {
        _text.text = "You can use the first one with L2 button or 1 key, and the second one with R2 button or 2 key";
        pu.enabled = true;
        if (timer >= 5)
        {
            pu.enabled = false;
            timer = 0;
            steps++;
        }
    }

    void showObjectsV()
    {
        _text.text = "Be careful with some object that fall from the sky";
        if (!stepdone)
        {
            Debug.Log("spawned");
            spawnerV.instance.spawn();
            stepdone = true;
        }
        if (timer >= 5)
        {
            timer = 0;
            steps++;
        }
    }

    void startPlaying()
    {
        _text.text = "Okay, are you ready?\nPress                   to play";
        play.enabled = true;
        if (Input.GetButton("Start"))
        {
            play.enabled = false; 
            SceneManager.LoadScene("Game");
        }
    }


    IEnumerator addTimer()
    {
        while (true)
        {
            timer++;
            yield return new WaitForSeconds(1.0f);
        }
    }

}
