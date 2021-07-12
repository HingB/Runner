using UnityEngine;

public class PanelOnDeadOpener : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Dead += OnPlayerDead;
    }

    private void OnDisable()
    {
        _player.Dead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        _panel.SetActive(true);
    }
}
