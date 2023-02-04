using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public Vector3 direction;
    public float speedTime;
    public float speedMax;

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameRunning)
        {
            transform.Translate(direction * (speedTime * Time.deltaTime));
            speedTime = Mathf.Clamp(
                  speedTime + speedTime * Time.deltaTime,
                  0,
                  speedMax
            );
        }
    }
}
