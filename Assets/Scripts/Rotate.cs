using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotate = 150f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.Rotate(Vector3.forward, rotate * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            transform.Rotate(Vector3.back, rotate * Time.deltaTime);
        }
    }
}
