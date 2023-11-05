using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smooth : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;

    void LateUpdate()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.position + offset;//target.TransformPoint(new Vector3(0, 5, -10));

        // Smoothly move the camera towards that target position
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
         
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
