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

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.back, -rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }
}
