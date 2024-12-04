using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private InputReader _input;

    void OnEnable()
    {
        _input.ActionPerformed += DisableReadyPanel;
    }

    void OnDisable()
    {
        _input.ActionPerformed -= DisableReadyPanel;
    }

    private void DisableReadyPanel()
    {
        _startScreen.SetActive(false);
    }
}