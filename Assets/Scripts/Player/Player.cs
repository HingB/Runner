using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coinToAdd;

    public event UnityAction Dead;
    public event UnityAction<int> CoinsCountChanged;
    private int _coinsCount;

    private void Start()
    {
        CoinsCountChanged?.Invoke(_coinsCount);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Die();
        }
    }

    public void AddCoin()
    {
        _coinsCount += _coinToAdd;

        CoinsCountChanged?.Invoke(_coinsCount);
    }

    private void Die()
    {
        Dead?.Invoke();
    }
}
