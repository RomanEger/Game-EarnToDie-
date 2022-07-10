using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    //public float pace;
    /*void Start()
    {
        zombie = GetComponent<Rigidbody2D>();
    }*/
    public float speed;
    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
