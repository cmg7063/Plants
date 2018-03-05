using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float rotateSpeed;
    bool wallCheck;
    bool seedCheck;

	// Use this for initialization
	void Start () {
        speed = 0.1f;
        rotateSpeed = 270f;
        seedCheck = false;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.back, -rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Seed")
        {
            Destroy(collision.gameObject);
            Debug.Log("test");
            seedCheck = true;
        }

        if (collision.gameObject.tag == "Pot" && seedCheck == true)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            seedCheck = false;
        }
    }
}
