using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public BallTracker ballTracker;
    public GameObject objectToSpawn;
    public int initialSpawnNo;
    private Vector3 spawnPosition;

    void Start()
    {
        Populate();
    }

    public void Populate()
    {
        for (int i = 0; i < initialSpawnNo; i++)
        {
            ballTracker.IncrementBall(objectToSpawn);
            spawnPosition = new Vector3(Random.Range(0.0f, 0.5f) + this.transform.position.x, 2.0f, Random.Range(0.0f, 0.5f) + this.transform.position.z);
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
