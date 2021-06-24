using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawner = Instantiate(prefab, _container.transform);
            spawner.SetActive(false);

            _pool.Add(spawner);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }

    public void StopAllObjects()
    {
        foreach (var item in _pool)
        {
            item.GetComponent<ObjectOnWayMover>().StopMoving();
        }
    }
}
