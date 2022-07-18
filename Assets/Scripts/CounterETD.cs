using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterETD : MonoBehaviour
{
    public bool Points = false;

    public static bool GameIsFinished = false;

    public GameObject endMenuUI;

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsFinished)
            {
                Finish();
            }
        }
    }*/

    void Finish()
    {
        endMenuUI.SetActive(true);

        Time.timeScale = 0f;

        GameIsFinished = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Points = true;
            Finish();        }
        /*if (Points == true)
        {
            Debug.Log("Уровень пройден");
            Time.timeScale = 0f;
            SceneManager.LoadScene("Home Menu");
            Time.timeScale = 1f;
        }*/
    }
}
/*
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f;

        GameIsPaused = true;
    }
 */