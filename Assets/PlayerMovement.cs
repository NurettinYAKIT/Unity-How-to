using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forwardForce = 1200f;
    public float sideWayforce = 500f;

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
        rigidbody.AddForce(horizontalSpeed, 0, verticalSpeed);
    }
}
