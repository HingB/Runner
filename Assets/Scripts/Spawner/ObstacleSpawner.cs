using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : Spawner
{
    private void Update()
    {
        if (SpawnIsStopped) return;
        TimeAfterLastSpawn += Time.deltaTime;

        if (TimeAfterLastSpawn >= TimeBetweenSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if (TryGetObject(out GameObject obstacle))
        {
            TimeAfterLastSpawn = 0;

            Vector3 spawnPoint = SpawnPoint.position;
            SetObject(obstacle, spawnPoint);
        }
    }
}
