using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static string language;
    public static bool gameRunning = false;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0;
        }
      
    }

}
