using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float camSmoothness;

    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        transform.position =
            Vector3.SmoothDamp(transform.position, playerTransform.position, ref velocity, camSmoothness) + offset;
    }
}
