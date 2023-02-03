using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSpawner : MonoBehaviour
{
    [Header("Spawn Scenario")]
    public GameObject[] prefabScenario;
    public float delayBetween;
    private int indexScenario = 0;


    void Awake()
    {
        if (GameController.gameRunning)
        {
            InvokeRepeating("SpawnScenario", 2f, delayBetween);
        }

    }
    void Update()
    {
   
    }

    void SpawnScenario()
    {
        indexScenario = Random.Range(0, prefabScenario.Length);
        Instantiate(prefabScenario[indexScenario], transform.position, prefabScenario[indexScenario].transform.rotation);
    }
}
