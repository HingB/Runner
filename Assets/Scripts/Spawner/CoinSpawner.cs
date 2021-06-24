using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private int _maxSpawnCoinsCount;
    [SerializeField] private int _minSpawnCoinsCount;

    private void Update()
    {
        if (SpawnIsStopped) return;
        TimeAfterLastSpawn += Time.deltaTime;

        if(TimeAfterLastSpawn >= TimeBetweenSpawn)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        int spawnCoinsCount = Random.Range(_minSpawnCoinsCount, _maxSpawnCoinsCount);

        for (int i = 0; i <= spawnCoinsCount; i++)
        {
            if (TryGetObject(out GameObject coin))
            {
                TimeAfterLastSpawn = 0;

                Vector3 spawnPoint = SpawnPoint.position;
                spawnPoint.x += i;

                SetObject(coin, spawnPoint);
            }
        }
    }
}
