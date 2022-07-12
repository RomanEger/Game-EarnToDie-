using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterETD : MonoBehaviour
{
    public bool Points = false;

    //public GameObject Car;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Points = true;
            Debug.Log("Уровень пройден");
            Time.timeScale = 0f;
            SceneManager.LoadScene("Home Menu");
            Time.timeScale = 1f;
        }
    }
}
