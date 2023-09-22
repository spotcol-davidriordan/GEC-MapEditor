using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 input = Vector2.zero;
    private Vector3 targetPosition = new Vector3(0, 0, -10f);

    private Vector3 currentVelocity;
    public float sensitivity;
    public float smoothTime = 0.2f;

    private void Update()
    {
        // move camera
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        targetPosition += (Vector3)(input * sensitivity) * Time.deltaTime;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}