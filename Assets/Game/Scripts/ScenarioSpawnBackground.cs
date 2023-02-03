using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSpawnBackground : MonoBehaviour
{
    [Header("Spawn Scenario")]
    public GameObject[] prefabScenario;
    public float delayBetween = 9f;
    private int indexScenario = 0;


    void Awake()
    {
        if (GameController.gameRunning)
        {
            InvokeRepeating("SpawnScenario", 2f, delayBetween);
        }

    }

    void SpawnScenario()
    {
        indexScenario = Random.Range(0, prefabScenario.Length);
        Instantiate(prefabScenario[indexScenario], prefabScenario[indexScenario].transform.position, prefabScenario[indexScenario].transform.rotation);
    }
}
