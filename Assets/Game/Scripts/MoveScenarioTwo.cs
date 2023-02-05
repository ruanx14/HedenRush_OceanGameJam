using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveScenarioTwo : MonoBehaviour
{
    public Vector3 direction;
    public float speedChanger = 0.2f;
    public float speedScenarioTwo = 1f;
    public float speedMax = 20;



    void Awake()
    {
        speedScenarioTwo = GameController.speedScenarioTwo;
    }
    void Update()
    {
        if(GameController.gameRunning)
        {
            transform.Translate(direction * (speedScenarioTwo * Time.deltaTime));
            speedScenarioTwo = Mathf.Clamp(
                  speedScenarioTwo + speedChanger * Time.deltaTime,
                  0,
                  speedMax
            );
        }
        //Debug.Log(speedScenarioTwo);
    }
}
