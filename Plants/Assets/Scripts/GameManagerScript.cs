using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	public GameObject[] seedsPrefabs;
	public GameObject tiltedEarthPrefab;

	public Vector3 mapMinPoint;
	public Vector3 mapMaxPoint;
	public float offset;

	private GameObject[] currentSeeds;
	private List<Vector3> tiltedLocations = new List<Vector3>();


	int frameCounter;

	// Use this for initialization
	void Start () {
		setUpArrays();
		// spawn two seeds and two tilted earth tiles at start
		SpawnTiltedEarth ();
		SpawnTiltedEarth ();
		SpawnTiltedEarth ();
		SpawnTiltedEarth ();
        SpawnSeed();
        SpawnSeed();
    }
	
	// Update is called once per frame
	void Update () {
		if ((frameCounter % 5) == 0) {
			currentSeeds = GameObject.FindGameObjectsWithTag ("Seed");

			if (currentSeeds.Length < 2) {
                SpawnTiltedEarth();
                SpawnTiltedEarth();
                SpawnSeed();
                ScoreTrack.scoreNum += 10;
            }
		}

		// update frameCounter
		frameCounter++;
		// prevent frameCounter from going to high
		if (frameCounter >= 99) {
			frameCounter = 0;
		}
	}

	//update x and y arrays
	void setUpArrays() {
		float mapWidth = (-mapMinPoint.x) + mapMaxPoint.x;
		float mapHeight = (-mapMinPoint.y) + mapMaxPoint.y;

		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {
				Vector3 temp = new Vector3 (x + mapMinPoint.x + 0.5f, y + mapMinPoint.y + 0.5f, -2.0f); 
				tiltedLocations.Add(temp);
			}
		}
	}

	//Spawns seed
	void SpawnSeed() {
		int randomSeed = Random.Range (0, seedsPrefabs.Length);

        int index = Random.Range(0, tiltedLocations.Count);
        Vector3 location = tiltedLocations[index];

		// add offsets
		location.z -= 1.0f;

        Instantiate(seedsPrefabs[randomSeed], location, seedsPrefabs[randomSeed].transform.rotation);
	}

	//Spawns tilted earth tile
	void SpawnTiltedEarth() {
		int index = Random.Range (0, tiltedLocations.Count);
		Vector3 location = tiltedLocations [index];

		Instantiate(tiltedEarthPrefab, location, tiltedEarthPrefab.transform.rotation);

		tiltedLocations.RemoveAt (index);
	}
}
