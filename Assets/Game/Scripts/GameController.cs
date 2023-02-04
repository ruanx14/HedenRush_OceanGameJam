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
    public float maxSpeedScenario = 15f;

    [Header("MonstersSpeed")]
    public float speedChangerMonster = 0.2f;
    public float speedMonster = 1f;
    public float maxSpeedMonster = 20f;

    
    /*
     [Header("ScenarioTwoSpeed")]
    public float speedChangerScenarioTwo = 0.2f;
    public float speedScenarioTwo = 1f;
    public float maxSpeedScenarioTwo = 15f; 
    */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                UnPauseGame();
            }
            else
            {
                PauseGame();
            };
        }
        //Speed Controller
        if (gameRunning)
        {
            SpeedController();
        }

    }

    public void SpeedController()
    {
            
             speedScenario = Mathf.Clamp(
                speedScenario + speedChanger * Time.deltaTime,
                0,
                maxSpeedScenario
            );


            speedMonster = Mathf.Clamp(
                speedMonster + speedChangerMonster * Time.deltaTime,
                0,
                maxSpeedMonster
            );




        /*
            speedScenarioTwo = Mathf.Clamp(
                speedScenarioTwo + speedChangerScenarioTwo * Time.deltaTime,
                0,
                maxSpeedScenarioTwo
            ); 
        */
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void CloseGame()
    {
        Application.Quit();
    }

}
