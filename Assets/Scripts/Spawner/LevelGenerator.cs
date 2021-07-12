using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GridObject[] _templates;
    [SerializeField] private Transform _player;
    [SerializeField] private float _viewRadius;
    [SerializeField] private float _cellSize;
    [SerializeField] private int _zGridSize;
    [SerializeField] private int _minLineOfObjectSize;
    [SerializeField] private int _maxLineOfObjectSize;
    [SerializeField] private int _chanceOfCreateMethLine;

    private HashSet<Vector3Int> _collisionMatrix = new HashSet<Vector3Int>();

    private void Update()
    {
        FillRadius(_player.position, _viewRadius);
    }

    private void FillRadius(Vector3 center, float viewRadius)
    {
        var cellCountOnRadius = (int)(viewRadius / _cellSize);
        var fillAreaCenter = WorldToGridPosition(center);

        for (int x = -cellCountOnRadius; x < cellCountOnRadius; x++)
        {
            for (int z = -_zGridSize; z < _zGridSize; z++)
            {
                TryCreateOnLayer(GridLayer.Ground, ObjectType.Road, fillAreaCenter + new Vector3Int(x, 0, z));
                TryCreateRandomObjectOnLayer(GridLayer.OnGround, fillAreaCenter + new Vector3Int(x, 0, 0));
            }
        }
    }

    private void TryCreateRandomObjectOnLayer(GridLayer layer, Vector3Int gridPostion)
    {
        gridPostion.y = (int)layer;

        if (_chanceOfCreateMethLine >= Random.Range(0, 100))
        {
            TryCreateLineOfMeth(gridPostion);
        }
        else
        {
            TryCreateOnLayer(layer, ObjectType.Obstacle, gridPostion);
        }
    }

    private void TryCreateLineOfMeth(Vector3Int startOfGridPosition)
    {
        Vector3Int spawnGridPosition;
        int lineLength = Random.Range(_minLineOfObjectSize, _maxLineOfObjectSize);

        for (int i = 0; i < lineLength; i++)
        {
            if (_collisionMatrix.Contains(startOfGridPosition + new Vector3Int(i, 0, 0)))
                return;
        }


        var template = TryGetTemplate(ObjectType.Meth);

        for (int i = 0; i < lineLength; i++)
        {
            spawnGridPosition = startOfGridPosition + new Vector3Int(i, 0, 0);

            Vector3 spawnPosition = GridToWorldPosition(spawnGridPosition);
            _collisionMatrix.Add(spawnGridPosition);

            if (template != null)
                Instantiate(template, spawnPosition, Quaternion.identity, _container);
        }
    }

    private void TryCreateOnLayer(GridLayer layer, ObjectType type, Vector3Int gridPosition)
    {
        gridPosition.y = (int)layer;

        if (_collisionMatrix.Contains(gridPosition))
            return;
        else
            _collisionMatrix.Add(gridPosition);

        var template = TryGetTemplate(type);

        if (template == null)
            return;

        var position = GridToWorldPosition(gridPosition);

        if (position == _player.position.normalized)
            return;

        Instantiate(template, position, Quaternion.identity, _container);
    }

    private GridObject TryGetTemplate(ObjectType type)
    {
        var variants = _templates.Where(template => template.Type == type);

        foreach (var variant in variants)
        {
            if (variant.Chance > Random.Range(0, 100))
                return variant;
        }

        return null;
    }

    private Vector3 GridToWorldPosition(Vector3Int gridPosition)
    {
        return new Vector3(
            gridPosition.x * _cellSize,
            gridPosition.y * _cellSize,
            gridPosition.z * _cellSize);
    }

    private Vector3Int WorldToGridPosition(Vector3 worldPosition)
    {
        return new Vector3Int(
            (int)(worldPosition.x / _cellSize),
            (int)(worldPosition.y / _cellSize),
            (int)(worldPosition.z / _cellSize));
    }
}
