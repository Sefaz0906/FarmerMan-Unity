using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smooth;
    public Vector3 offset;

    void FixedUpdate()
    {
        if(target  != null)
        {
        Vector3 newPosition = Vector3.Lerp (transform.position, target.transform.position + offset, smooth);
        transform.position = newPosition;
        }
    }
}
