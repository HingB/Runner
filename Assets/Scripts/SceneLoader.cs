using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button _loadButton;
    [SerializeField] private string _sceneName;

    private void OnEnable()
    {
        _loadButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _loadButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
