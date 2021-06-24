using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsOnWayStopper : MonoBehaviour
{
    [SerializeField] private Player _player;

    private ObjectPool[] _pools;

    private void OnEnable()
    {
        _player.Dead += OnPlayerDead;
    }

    private void OnDisable()
    {
        _player.Dead -= OnPlayerDead;
    }

    private void Start()
    {
        _pools = FindObjectsOfType<ObjectPool>();
    }

    private void OnPlayerDead()
    {
        foreach (var pool in _pools)
        {
            pool.StopAllObjects();
        }
    }
}
