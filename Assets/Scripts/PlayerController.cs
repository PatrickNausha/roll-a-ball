using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        var momentVector = movementValue.Get<Vector2>();
        movementX = momentVector.x;
        movementY = momentVector.y;
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(movementX, 0, movementY) * Speed);
    }

    private Rigidbody rb;
    private float movementX;
    private float movementY;
}
