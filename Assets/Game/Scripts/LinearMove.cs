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
    public float speedNow;

    void Awake()
    {
        gameScript = gameController.GetComponent<GameController>();
        speedNow = gameScript.speedScenario;
    }
    void Update()
    {
        if (GameController.gameRunning)
        {
                speedNow = gameScript.speedScenario;
                transform.Translate(direction * (speedNow * Time.deltaTime));
        }
    }
}
