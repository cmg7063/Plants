using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltedGroundScript : MonoBehaviour {
	// Flower
	public GameObject[] flowerPrefabs;
	public float bloomTime;
	private bool isPlanted = false;
	private bool flowerBloomed = false;

	// Sprite
	public Sprite plantedSprite;
	private SpriteRenderer spriteRenderer; 

	private int frameCounter;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		frameCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlanted && !flowerBloomed) {
			if (bloomTime > 0.0f) {
				bloomTime -= Time.deltaTime;
			} else {
				SpawnFlower ();
				flowerBloomed = true;
			}
		} else if (flowerBloomed) {
			if (frameCounter % 60 == 0) {
				ScoreTrack.scoreNum++;
			}

			frameCounter++;
			if (frameCounter >= 59) {
				frameCounter = 0;
			}
		}
	}

	public bool GetIsPlanted() {
		return isPlanted;
	}

	public void PlantSeed() {
		spriteRenderer.sprite = plantedSprite;
		isPlanted = true;
	}

	//Spawns Flower
	private void SpawnFlower() {
		int index = Random.Range (0, flowerPrefabs.Length);
		Vector3 location = gameObject.transform.position;

		// add offset for flower
		location.y += 0.1f;
		location.z -= 1.0f;

		Instantiate(flowerPrefabs[index], location, gameObject.transform.rotation);
	}
}
