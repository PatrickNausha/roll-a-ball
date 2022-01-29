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

        // Make things less jittery
        // https://docs.unity3d.com/ScriptReference/Rigidbody-interpolation.html
        playerRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void LateUpdate()
    {
        var lookAtTarget = Player.transform.position + playerRigidbody.velocity * velocityLeadOffsetScaleFactor;
        var discard = new Vector3();
        transform.position = Vector3.SmoothDamp(transform.position, lookAtTarget + offsetFromLookat, ref discard, smoothDampTime);
    }

    private Vector3 offsetFromLookat;
    private float velocityLeadOffsetScaleFactor = 0.5f;
    private float smoothDampTime = 0.1f;
    private Rigidbody playerRigidbody;
}
