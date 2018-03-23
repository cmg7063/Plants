using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour {

	public Transform player;
	public Vector3 offset;

	GameObject[] seeds;
	GameObject target;

	int frameCounter;

	// Use this for initialization
	void Start () {
		seeds = GameObject.FindGameObjectsWithTag("Seed");

		frameCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.position + offset;

		// prevent constantly update array and target
		if ((frameCounter % 5) == 0) {
			// update seeds array
			seeds = GameObject.FindGameObjectsWithTag ("Seed");

			// find closest target
			target = FindClosestSeed ();
		}

		// if target exist point to it
		// else hide compass
		if (target) {
			gameObject.GetComponent<Renderer>().enabled = true;
			Follow (target);
		} else {
			gameObject.GetComponent<Renderer> ().enabled = false;
		}

		// update frameCounter
		frameCounter++;
		// prevent frameCounter from going to high
		if (frameCounter >= 100) {
			frameCounter = 0;
		}
	}

	// find closest enemy 
	private GameObject FindClosestSeed() {
		GameObject closest = null;
		float distance = Mathf.Infinity;

		foreach (GameObject seed in seeds) {
			Vector3 diff = seed.transform.position - gameObject.transform.position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = seed;
				distance = curDistance;
			}
		}

		return closest;
	}

	// follow the targeted object
	private void Follow(GameObject targetObj) {
		Vector3 dir = targetObj.transform.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
	}
}
