using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;
    public float rotateSpeed;

    // Use this for initialization
    void Start () {
        smoothSpeed = 0.125f;
        rotateSpeed = 270f;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;

        transform.rotation = target.rotation;
    }
}
