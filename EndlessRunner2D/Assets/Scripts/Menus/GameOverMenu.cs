using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
