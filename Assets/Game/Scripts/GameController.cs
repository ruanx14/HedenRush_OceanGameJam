using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Game Settings")]
    public static bool gameRunning = false;
    public static bool canMove = false;
    public GameObject pauseMenu;


    [Header("ScenarioSpeed")]
    public float speedChanger = 0.2f;
    public float speedScenario = 1f;
    public float maxSpeedScenario = 20f;

    [Header("SpeedScenarioTwo")]
    public static float speedScenarioTwo = 1f;

    public GameObject joystickMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseController();
        }
        //Speed Controller
        if (gameRunning)
        {
            SpeedController();
            speedScenarioTwo = speedScenario;
        }

    }

    public void SpeedController()
    {
             speedScenario = Mathf.Clamp(
                speedScenario + speedChanger * Time.deltaTime,
                0,
                maxSpeedScenario
            );
    }
    public void PauseController()
    {
        if (gameRunning)
        {
            if (Time.timeScale == 0)
            {

                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                joystickMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                joystickMenu.SetActive(true);
            }
        }
    }
     public void CloseGame()
    {
        Application.Quit();
    }

}
