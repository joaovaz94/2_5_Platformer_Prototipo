using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform alvo;
    private Vector3 offset;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            alvo = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            alvo = GameObject.FindGameObjectWithTag("Respawn").transform;
        }

        offset = transform.position - alvo.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            alvo = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            alvo = GameObject.FindGameObjectWithTag("Respawn").transform;
        }
        transform.position = alvo.position + offset;   
    }
}
