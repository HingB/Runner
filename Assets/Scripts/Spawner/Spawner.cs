using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] protected float TimeBetweenSpawn;
    [SerializeField] protected Transform SpawnPoint;

    protected float TimeAfterLastSpawn;
    protected bool SpawnIsStopped;

    private Player _player;

    private void Start()
    {
        Initialize(_prefab);
    }

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();

        _player.Dead += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Dead -= OnPlayerDied;
    }

    protected void SetObject(GameObject prefab, Vector3 spawnPoint)
    {

        prefab.SetActive(true);
        prefab.transform.position = spawnPoint;
    }

    private void OnPlayerDied()
    {
        SpawnIsStopped = true;
    }
}
