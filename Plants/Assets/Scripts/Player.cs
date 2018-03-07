using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float rotateSpeed;
    bool wallCheck;
    int seedCount;

	// Use this for initialization
	void Start () {
        speed = 0.1f;
        rotateSpeed = 270f;
        seedCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!wallCheck)
        {
            transform.Translate(0, speed, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.back, -rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 direction = transform.InverseTransformPoint(collision.transform.position);
        if (direction.y < 0f)
        {
            wallCheck = true;
        } else
        {
            wallCheck = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        wallCheck = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Seed")
        {
            Destroy(collision.gameObject);
            seedCount++;
        }

        if (collision.gameObject.tag == "Pot" && seedCount > 0)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            seedCount--;
        }
    }
}
