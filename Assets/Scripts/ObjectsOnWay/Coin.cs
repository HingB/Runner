using UnityEngine;

public class Coin : ObjectOnWay
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddCoin();
            gameObject.SetActive(false);
        }
    }
}
