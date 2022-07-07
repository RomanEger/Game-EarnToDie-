using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player; // тут объект игрока

    public Vector3 offset = new Vector3(8, 3, -10);

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        
        transform.position = player.transform.position + offset;
    }
    
}
