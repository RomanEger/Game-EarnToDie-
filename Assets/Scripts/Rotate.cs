using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotate = 150f;

    void Update()
    {
        //наклон назад
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Rotate(Vector3.forward, rotate * Time.deltaTime);
        }
        //наклон вперед
        else if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Rotate(Vector3.back, rotate * Time.deltaTime);
        }
    }
}
