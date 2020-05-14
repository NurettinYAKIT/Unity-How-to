using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forwardForce = 1200f;
    public float sideWayforce = 50f;

    private float verticalSpeed;
    private float horizontalSpeed;

    void Update()
    {
        verticalSpeed = Input.GetAxis("Vertical") * forwardForce * Time.deltaTime;
        horizontalSpeed = Input.GetAxis("Horizontal") * sideWayforce * Time.deltaTime;
    }

    // FixedUpdate is better when you are working with pyhcics.
    void FixedUpdate()
    {
        rigidbody.AddForce(0, 0, verticalSpeed);
        rigidbody.AddForce(horizontalSpeed, 0, 0,ForceMode.VelocityChange);

        if(rigidbody.position.y<-1f){
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void oldWay()
    {
        if (Input.GetKey("w"))
        {
            rigidbody.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rigidbody.AddForce(-sideWayforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rigidbody.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rigidbody.AddForce(sideWayforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
