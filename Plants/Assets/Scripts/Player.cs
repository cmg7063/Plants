using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	// player
	Rigidbody2D rigidBody;

	// movement
    public float speed;
    public float rotateSpeed;
    
	// collectable
    int seedCount;

	// wall collision properties
	float currentStun;
	float stunTime;
	bool restrictRotation;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();

		seedCount = 0;

		currentStun = 0.0f;
		stunTime = 1.75f;
		restrictRotation = false;
	}
	
	// Update is called once per frame
	void Update () {
		updateMovement ();

		userInput ();
    }

	// move players if they are not stunned
	private void updateMovement() {
		if (currentStun < 0.0f) {
			transform.Translate (0, speed * Time.deltaTime, 0);
		} else {
			// push back player during the beginning of the stun
			if (currentStun > 1.0f) {
				transform.Translate (0, -(currentStun - 1.0f) * 3 * Time.deltaTime, 0);
			} else {
				restrictRotation = false;
			}

			currentStun -= Time.deltaTime;
		}
	}

	// checks for user input
	private void userInput() {
		// rotate player counter clockwise
		if (!restrictRotation) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (Vector3.back, -rotateSpeed * Time.deltaTime);
			}

			// rotate player clockwise
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (Vector3.back, rotateSpeed * Time.deltaTime);
			}
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Seed") {
			Destroy(collision.gameObject);
			seedCount++;
		}

		if (collision.gameObject.tag == "Wall") {
			currentStun = stunTime;
			restrictRotation = true;
		}
    }

    private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Pot" && seedCount > 0) {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
