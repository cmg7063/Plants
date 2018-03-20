using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{

    // Spawn this object
    public GameObject seed;

    public float maxTime = 5;
    public float minTime = 2;
    private float time; // current time


    // The time to spawn the object
    private float spawnTime;

    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {

        time += Time.deltaTime;

        // Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnSeed();
            SetRandomTime();
        }

    }

    //Spawns the object and resets the time
    void SpawnSeed()
    {
        time = 0;
        Instantiate(seed, transform.position, seed.transform.rotation);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

}