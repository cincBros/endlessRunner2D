﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{


    public static AudioClip xiulet, boing, getPildora, getCasc, alarm, clock, jump, hit, addPU, enemyHit, birdHit, coneHit;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {

        xiulet = Resources.Load<AudioClip>("xiulet");
        boing = Resources.Load<AudioClip>("boing");
        getPildora = Resources.Load<AudioClip>("getPildora");
        getCasc = Resources.Load<AudioClip>("getCasc");
        alarm = Resources.Load<AudioClip>("alarm");
        clock = Resources.Load<AudioClip>("clock");
        jump = Resources.Load<AudioClip>("jump");
        hit = Resources.Load<AudioClip>("hit");
        addPU = Resources.Load<AudioClip>("addPU");
        enemyHit = Resources.Load<AudioClip>("enemyHit");
        birdHit = Resources.Load<AudioClip>("birdHit");
        coneHit = Resources.Load<AudioClip>("coneHit");

        audioSrc = GetComponent<AudioSource>();
        DontDestroyOnLoad(audioSrc);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.instance.viu)
        {
            audioSrc.Stop();
        }
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "xiulet":
                audioSrc.PlayOneShot(xiulet);
                break;
            case "boing":
                audioSrc.PlayOneShot(boing);
                break;
            case "getPildora":
                audioSrc.PlayOneShot(getPildora);
                break;
            case "getCasc":
                audioSrc.PlayOneShot(getCasc);
                break;
            case "alarm":
                audioSrc.PlayOneShot(alarm);
                break;
            case "clock":
                audioSrc.PlayOneShot(clock);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "addPU":
                audioSrc.PlayOneShot(addPU);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHit);
                break;
            case "birdHit":
                audioSrc.PlayOneShot(birdHit);
                break;
            case "coneHit":
                audioSrc.PlayOneShot(coneHit);
                break;
        }
    }
}
