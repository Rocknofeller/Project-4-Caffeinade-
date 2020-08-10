using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField]
    private GameObject customerPrefab;
    [SerializeField]
    private float spawnDelay = 5;

    private void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
            
        }
    }

    private void Spawn()
    {
        
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(customerPrefab, transform.position, transform.rotation);
        
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
        
    }
}
