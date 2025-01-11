using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private InputReader _input;

    void OnEnable()
    {
        _input.AnyKey += DisableReadyPanel;
    }

    void OnDisable()
    {
        _input.AnyKey -= DisableReadyPanel;
    }

    private void DisableReadyPanel()
    {
        _startScreen.SetActive(false);
    }
}