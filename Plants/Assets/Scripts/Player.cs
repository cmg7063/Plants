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

    //touch stuff
    private Vector2 touchOrigin;
    private Vector2 touchOld;

    private float desiredRot;

    public float rotSpeed = 250;
    public float damping = 10;

	// Use this for initialization

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();

		seedCount = 0;

		currentStun = 0.0f;
		stunTime = 1.75f;
		restrictRotation = false;

        touchOrigin = -Vector2.one;
        touchOld = -Vector2.one;

        desiredRot = transform.eulerAngles.y;
    }
	
	// Update is called once per frame
	void Update () {
		updateMovement ();

		userInput ();
    }

	// move players if they are not stunned
	private void updateMovement() {
        if (currentStun < 0.0f) {
			transform.Translate (0, (speed + ScoreTrack.scoreNum/100) * Time.deltaTime, 0);
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
		#if (UNITY_STANDALONE || WEBPLAYER || UNITY_EDITOR_WIN || UNITY_EDITOR_OSX)
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
		#else
	        if(Input.touchCount > 0)
	        {
	            Touch tch = Input.touches[0];

                if(tch.phase == TouchPhase.Began)
                {
                    if(tch.position == null)
                    {
                        return;
                    }
                    touchOrigin = tch.position;
                    touchOld = tch.position;
                }
                else if(tch.phase == TouchPhase.Moved)
	            {
	                touchOrigin = tch.position;
	                if (touchOrigin.x >= touchOld.x)
	                {
	                    transform.Rotate(Vector3.back, ((touchOrigin.x - touchOld.x) / 10) * rotateSpeed * Time.deltaTime);
	                }
	                else
	                {
	                    transform.Rotate(Vector3.back, ((touchOld.x - touchOrigin.x) / 10) * -rotateSpeed * Time.deltaTime);
	                }
	                touchOld = touchOrigin;
                }
	        }
		#endif
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
