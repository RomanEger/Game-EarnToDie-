using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{
    public GameObject zombie;

    //public Rigidbody2D GameObject;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Зомби умер");
            Destroy(zombie);
        }
    }
}
