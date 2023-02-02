using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    //Jump
    private Rigidbody2D rb;
    [SerializeField]
    private float forceJump;
    [SerializeField]
    private float distanceFloor;
    [SerializeField]
    private LayerMask layerFloor;
    [SerializeField]
    private bool verifyFloor;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        verifyFloor = Physics2D.Raycast(transform.position, Vector2.down, distanceFloor, layerFloor);
    }
    private void Jump()
    {
        if (verifyFloor)
        {
            rb.AddForce(Vector2.up * forceJump);
        }
        //animatorComponent.SetBool("Jumping", true);
    }
    /*
     * private IEnumerator Die()
    {
        _isDead = true;
        transform.position = _initialDeathPosition;

        while (Vector3.Distance(transform.position, _initialPosition) > returnThreshold)
        {
            var direction = _initialPosition - transform.position;
            transform.position = Vector3.Slerp(
                transform.position,
                transform.position + direction,
                Time.deltaTime * returnSpeed
            );
            yield return null;
        }
        _isDead = false;

    }
    */
}
