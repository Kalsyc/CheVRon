using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSpawner : MonoBehaviour
{
    public EnemyTracker enemyTracker;
    public GameObject enemy;
    public int spawnNumber;
    private Vector3 spawnPosition;

    void Start()
    {
        Populate();
    }

    public void Populate()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            enemyTracker.IncrementGolem();
            spawnPosition = new Vector3(Random.Range(0.0f, 20.0f) + this.transform.position.x, 0.4f, Random.Range(0.0f, 20.0f) + this.transform.position.z);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
}
