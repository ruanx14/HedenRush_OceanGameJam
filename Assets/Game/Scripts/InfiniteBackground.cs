using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfiniteBackground : MonoBehaviour
{

    public float xPosition = -23f;
    void Update()
    {
        if (GameController.gameRunning)
        {
            if (transform.position.x < xPosition)
            {
                moveTerrain();
            }
        }
    }
    void moveTerrain()
    {
        transform.Translate(Vector3.right * 23f * 2);
    }
}
