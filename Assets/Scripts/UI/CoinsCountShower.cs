using UnityEngine;
using TMPro;

public class CoinsCountShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CoinsCountChanged += OnCoinsCountCanged;
    }

    private void OnDisable()
    {
        _player.CoinsCountChanged -= OnCoinsCountCanged;
    }

    private void OnCoinsCountCanged(int newValue)
    {
        _text.text = newValue.ToString();
    }
}
