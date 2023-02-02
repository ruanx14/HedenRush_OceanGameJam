using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialMoves : MonoBehaviour
{
    public GameObject canvas;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject ship;
    [SerializeField]
    private GameObject spotInFront;

    private Transform frontPosition;
    private Transform hidePosition;


    public float returnSpeed;

    void Awake()
    {
        frontPosition = spotInFront.transform;
        hidePosition = ship.transform;
        StartCoroutine(NaveComing());
    }
    IEnumerator NaveComing()    
    {
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
            player.SetActive(true);
            
            yield return new WaitForSeconds(2f);

        /*while (Vector3.Distance(ship.transform.position, hidePosition.position) > 2)
        {
            //Debug.Log(Vector3.Distance(ship.transform.position, frontPosition.transform.position));
            var direction = (hidePosition.position - ship.transform.position).normalized;
            ship.transform.position = Vector3.Slerp(
                ship.transform.position,
                hidePosition.position + direction,
                Time.deltaTime * returnSpeed
            );
            yield return null;
        }*/

        canvas.SetActive(true);
            
        
    }

}
