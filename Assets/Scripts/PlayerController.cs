using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0;
    public TextMeshProUGUI CountText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        var momentVector = movementValue.Get<Vector2>();
        movementX = momentVector.x;
        movementY = momentVector.y;
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(movementX, 0, movementY) * Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count = 0;
}
