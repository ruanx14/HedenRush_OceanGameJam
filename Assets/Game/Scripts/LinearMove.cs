using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour
{
    [Header("LinearMove")]
    [SerializeField]
    public Vector3 direction;


    private GameController gameScript;
    [SerializeField]
    GameObject gameController;
    public string speedSelector;

    void Awake()
    {
        gameScript = gameController.GetComponent<GameController>();
        
    }
    void Update()
    {
        if (GameController.gameRunning)
        {
            if (speedSelector == "scenario")
            {
                transform.Translate(direction * (gameScript.speedScenario * Time.deltaTime));
            }
            else if (speedSelector == "monster")
            {
                transform.Translate(direction * (gameScript.speedMonster * Time.deltaTime));
            }
        }
    }
}
