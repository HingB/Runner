using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Application.Quit();
    }
}
