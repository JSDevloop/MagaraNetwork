using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [HideInInspector] public Transform target;
    public Vector3 offset;
    public float speed = 3;
    Vector3 newPosition;
    void Update()
    {
        
    }
    void LateUpdate()
    {
        newPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    }
}
