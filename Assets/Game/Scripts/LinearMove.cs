using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour
{
    [Header("LinearMove")]
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
