using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] private ObjectType _type;
    [SerializeField] private int _chance;

    public ObjectType Type => _type;
    public int Chance => _chance;

    private void OnValidate()
    {
        _chance = Mathf.Clamp(_chance, 1, 100);
    }
}
