using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LinearMove : MonoBehaviour
{
    [SerializeField]
    public Vector3 direction;

    [SerializeField]
    public float speedTime;


    void Update()
    {
        if (GameController.gameRunning)
        {
            transform.Translate(direction * (speedTime * Time.deltaTime));
        }
    }
}
