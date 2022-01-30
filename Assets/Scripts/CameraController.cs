using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        offsetFromLookat = transform.position - Player.transform.position;
        playerRigidbody = Player.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        var discard = new Vector3();
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + offsetFromLookat, ref discard, smoothDampTime);
    }

    private Vector3 offsetFromLookat;
    private float smoothDampTime = 0.05f;
    private Rigidbody playerRigidbody;
}
