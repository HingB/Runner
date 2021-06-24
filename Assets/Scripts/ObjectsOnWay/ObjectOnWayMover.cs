using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnWayMover : MonoBehaviour
{
    private float _speed;
    private bool _isStopped;

    private void Start()
    {
        _speed = FindObjectOfType<ObjectOnWaySpeedKeeper>().Speed;
    }

    private void Update()
    {
        if (_isStopped) return;
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

    public void StopMoving()
    {
        _isStopped = true;
    }
}

