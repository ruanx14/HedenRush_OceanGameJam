using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfiniteBackground : MonoBehaviour
{

    public float xPosition = 19f;
    void Update()
    {

        if (transform.position.x < xPosition)
        {
            moveTerrain();
        }
    }
    void moveTerrain()
    {
        transform.Translate(Vector3.right * 19f * 2);
    }
}
