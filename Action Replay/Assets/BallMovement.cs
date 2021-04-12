using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float forceSize;

    private Vector3 forceDirection;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        forceDirection = new Vector3(horizontalInput, 0, verticalInput);
        forceDirection.Normalize();
    }

    void FixedUpdate()
    {
        Vector3 force = forceDirection * forceSize;

        rigidbody.AddForce(force);
    }
}
