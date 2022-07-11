using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home_menu : MonoBehaviour
{
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Start();
        }
        else
        {
            Resume();
        }
    }*/

    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Game");
    }

    public void Settings()
    {
        Debug.Log("Settings");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit"); 
        Application.Quit();
    }
}
