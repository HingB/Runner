using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevelopersListShower : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Animation _panelWithDevelopersAnimation;

    private void OnEnable()
    {
        _openButton.onClick.AddListener(OnOpenButtonClick);
        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnDisable()
    {
        _openButton.onClick.AddListener(OnOpenButtonClick);
        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnOpenButtonClick()
    {
        _panelWithDevelopersAnimation.gameObject.SetActive(true);
        _panelWithDevelopersAnimation.Play("DevelopersPanelOpen");
    }

    private void OnCloseButtonClick()
    {
        _panelWithDevelopersAnimation.Play("DevelopersPanelClose");
    }
}
