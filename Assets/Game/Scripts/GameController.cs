using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //[Header("Game Settings")]
    public static string language;  
    public static bool gameRunning = false;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 5f;
        }

    }

}
