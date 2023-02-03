using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMoves : MonoBehaviour
{
    [Header("ShipMoving")]
    //public GameObject canvas; //Old Dialog Canvas
    [SerializeField]
    private GameObject ship;

    [Header("Transforms")]
    [SerializeField]
    private GameObject spotInFront;
    private Transform frontPosition;
    [SerializeField]
    private Transform hidePosition;

    [Header("ConfigGame")]
    [SerializeField]
    private GameObject player;
    public float returnSpeed;
    public GameObject catPet;
    public GameObject scenarioSpawn;

    void Awake()
    {
        frontPosition = spotInFront.transform;
        StartCoroutine(NaveComing());
    }
    IEnumerator NaveComing()    
    {
        yield return null;
        
        yield return new WaitForSeconds(2f);
        while (Vector3.Distance(ship.transform.position, frontPosition.position) > 2)
        {
            //Debug.Log(Vector3.Distance(ship.transform.position, frontPosition.transform.position));
            var direction = (frontPosition.transform.position - ship.transform.position).normalized;
            ship.transform.position = Vector3.Slerp(
                ship.transform.position,
                ship.transform.position + direction,
                Time.deltaTime * returnSpeed
            );
            yield return null;
        }
            //Debug.Log(ship.GetComponent<SpriteRenderer>());
            Destroy(ship.GetComponent<Animator>());
        
            yield return new WaitForSeconds(1f);
            player.SetActive(true);
            catPet.SetActive(true);
            yield return new WaitForSeconds(2f);
            player.GetComponent<Animator>().SetBool("isIdle", true);
            yield return new WaitForSeconds(1f);



        //canvas.SetActive(true);
        //yield return new WaitForSeconds(2f);
        while (Vector3.Distance(ship.transform.position, hidePosition.position) > 0.2f)
        {
            var direction = (hidePosition.position - ship.transform.position).normalized;
            ship.transform.position = Vector3.Slerp(
                ship.transform.position,
                hidePosition.position + direction,
                Time.deltaTime * 1f
            );
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Destroy(ship);

        player.GetComponent<Animator>().SetBool("isRunning", true);
        GameController.gameRunning = true;
        catPet.GetComponent<Animator>().SetBool("isIdle", false);
        scenarioSpawn.SetActive(true);
    }

}
