using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endSounds : MonoBehaviour
{
    public static AudioClip xiuletFinal;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        xiuletFinal = Resources.Load<AudioClip>("xiuletFinal");

        audioSrc = GetComponent<AudioSource>();
        DontDestroyOnLoad(audioSrc);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "xiuletFinal":
                audioSrc.PlayOneShot(xiuletFinal);
                break;

        }
    }
}
