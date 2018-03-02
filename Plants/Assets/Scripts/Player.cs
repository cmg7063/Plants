using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float rotateSpeed;

	// Use this for initialization
	void Start () {
        speed = 0.1f;
        rotateSpeed = 270f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.back, -rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }
}
